using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uniful.Lerp.LerpComponents
{
	/// <summary>
	/// Component exposes Vector3 lerping options and functionality to the Unity3D
	/// inspector providing an event-based callback for value changes during lerps utilizing the <see cref="UnityEngine.Events.UnityEvent"/> types.
	/// Provides designers a way to create simple lerping behaviours that programmers would otherwise need to implement in cumbersome and coupled classes
	/// for designers.
	public class Vector3LerpComponent : LerpBaseComponent<Vector3>
	{
#pragma warning disable 0649
		private Vector3 _CurrentValue;
#pragma warning restore 0649
		/// <summary>
		/// Current value of the lerp.
		/// </summary>
		public override Vector3 CurrentValue { get { return _CurrentValue; } }

		[SerializeField]
#pragma warning disable 0649
		private Vector3 _StartingValue;
#pragma warning restore 0649
		/// <summary>
		/// Starting value from which the lerp begins from.
		/// </summary>
		public override Vector3 StartingValue { get { return _StartingValue; } }

		[SerializeField]
#pragma warning disable 0649
		private Vector3 _TargetValue;
#pragma warning restore 0649
		/// <summary>
		/// Target end value for the lerp.
		/// </summary>
		public override Vector3 TargetValue { get { return _StartingValue; } }

		protected override Vector3 ComputeNextLerpValue()
		{
			_CurrentValue = Vector3.Lerp(_StartingValue, _TargetValue, this.lerpTimerService.timePassedDelta / this.lerpTimerService.TimeInterval);
			return this.CurrentValue;
		}
	}
}
