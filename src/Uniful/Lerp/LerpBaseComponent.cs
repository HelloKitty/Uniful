using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Uniful
{
	/// <summary>
	/// Abstract type for all lerping components. Inheritors expose lerping options and functionality to the Unity3D
	/// inspector. They provide an event-based callback for value changes during lerps utilizing the <see cref="UnityEngine.Events.UnityEvent"/> types.
	/// Provide designers a way to create simple lerping behaviours that programmers would otherwise need to implement in cumbersome and coupled classes
	/// for designers.
	/// </summary>
	/// <typeparam name="TLerpType">The type of lerp value.</typeparam>
	public abstract class LerpBaseComponent<TLerpType> : MonoBehaviour, ILerpValueQueryable<TLerpType>
	{
		/// <summary>
		/// Serializable generic event class that acts as a hack for Unity3D to serialize the event to the
		/// inspector.
		/// </summary>
		[Serializable]
		public abstract class LerpValueChangedEvent : UnityEvent<TLerpType> { }

		/// <summary>
		/// Serialized event object that maintains the list of object reference and methods to invoke.
		/// </summary>
		protected abstract LerpValueChangedEvent OnValueChanged { get; }

		/// <summary>
		/// Serialized event object that maintains a list of object reference and methods to invoke.
		/// Invokes when the lerp finishes.
		/// </summary>
		[SerializeField]
		private UnityEvent OnLerpEnded;

		//TODO: If needed a property can be made to expose these in code.
		/// <summary>
		/// Indicates if <see cref="FixedUpdate"/> should be used.
		/// If false <see cref="Update"/> is used.
		/// These a magic Unity methods so review that documentation.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		protected bool _useFixedUpdate;
#pragma warning restore 0649

		/// <summary>
		/// Indicates if this component should be destroyed on lerp finished.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		protected bool _DestroyOnFinished;
#pragma warning restore 0649

		/// <summary>
		/// Indicates if the lerp component is currently running a lerp.
		/// </summary>
		[HideInInspector]
		public bool isRunning { get; protected set; } = false;

		//We need to serialize this service so it can be configured by consumers in the Unity3D inspector.
		[SerializeField]
		protected LerpTimeService lerpTimerService;

		/// <summary>
		/// Current value of the lerp.
		/// </summary>
		public abstract TLerpType CurrentValue { get; }

		/// <summary>
		/// Starting value from which the lerp begins from.
		/// </summary>
		public abstract TLerpType StartingValue { get; }

		/// <summary>
		/// Target end value for the lerp.
		/// </summary>
		public abstract TLerpType TargetValue { get; }

		/// <summary>
		/// Inheritor will implement the lerp loop, or lerp logic, for the given <see cref="TLerpType"/>.
		/// This can not be written generically.
		/// </summary>
		protected abstract TLerpType ComputeNextLerpValue();

		public void StartLerp()
		{
			//It's probably a good idea to set the current value to the start value
			//When a start is requested since time will tick forward first call
			if (OnValueChanged != null)
				OnValueChanged.Invoke(StartingValue);

			isRunning = true;
		}

		public void PauseLerp()
		{
			isRunning = false;
		}

		/// <summary>
		/// Update loop that will move the lerp forward if non-fixed update.
		/// </summary>
		protected void Update()
		{
			if (this._useFixedUpdate)
				return;

			UpdateLogic();
		}

		/// <summary>
		/// FixedUpdate loop that will move the lerp forward if fixed update.
		/// </summary>
		protected void FixedUpdate()
		{
			if (this._useFixedUpdate)
				UpdateLogic();
		}

		/// <summary>
		/// Handles lerp logic and destruction of the component on finish if desired.
		/// </summary>
		private void UpdateLogic()
		{
			if (isRunning && !lerpTimerService.Finished)
			{
				//This MUST be done inside this condition because otherwise time will
				//tick forward during any Update and not only during lerp
				//Also, if you don't do this first then you encounter another fault
				//where values will never reach their true final lerp target.
				lerpTimerService.StepTimeForward();
				
				//Tick the lerp forward and broadcast changed value.
				//For now assume change during lerping.
				TLerpType lerpValue = ComputeNextLerpValue();

				if (OnValueChanged != null)
					OnValueChanged.Invoke(lerpValue);

				//Could be finished here, best place to check it
				if (lerpTimerService.Finished)
					if (OnLerpEnded != null)
						OnLerpEnded.Invoke();
			}

			if (lerpTimerService.Finished && _DestroyOnFinished)
				Destroy(this);


		}
	}
}
