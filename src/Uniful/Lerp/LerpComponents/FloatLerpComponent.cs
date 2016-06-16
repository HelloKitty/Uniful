using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uniful
{
	/// <summary>
	/// Component exposes float lerping options and functionality to the Unity3D
	/// inspector providing an event-based callback for value changes during lerps utilizing the <see cref="UnityEngine.Events.UnityEvent"/> types.
	/// Provides designers a way to create simple lerping behaviours that programmers would otherwise need to implement in cumbersome and coupled classes
	/// for designers.
	public class FloatLerpComponent : LerpBaseComponent<float>
	{
#pragma warning disable 0649
		private float _CurrentValue;
#pragma warning restore 0649
		/// <summary>
		/// Current value of the lerp.
		/// </summary>
		public override float CurrentValue { get { return _CurrentValue; } }

#pragma warning disable 0649
		[SerializeField]
		private float _StartingValue;
#pragma warning restore 0649
		/// <summary>
		/// Starting value from which the lerp begins from.
		/// </summary>
		public override float StartingValue { get { return _StartingValue; } }

#pragma warning disable 0649
		[SerializeField]
		private float _TargetValue;
#pragma warning restore 0649
		/// <summary>
		/// Target end value for the lerp.
		/// </summary>
		public override float TargetValue { get { return _StartingValue; } }

		protected override float ComputeNextLerpValue()
		{
			_CurrentValue = Mathf.Lerp(_StartingValue, _TargetValue, this.lerpTimerService.timePassedDelta / this.lerpTimerService.TimeInterval);
			return this.CurrentValue;
		}
	}
}
