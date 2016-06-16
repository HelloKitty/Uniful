﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uniful.Lerp.LerpComponents
{
	/// <summary>
	/// Component exposes color lerping options and functionality to the Unity3D
	/// inspector providing an event-based callback for value changes during lerps utilizing the <see cref="UnityEngine.Events.UnityEvent"/> types.
	/// Provides designers a way to create simple lerping behaviours that programmers would otherwise need to implement in cumbersome and coupled classes
	/// for designers.
	public class ColorLerpComponent : LerpBaseComponent<Color>
	{
#pragma warning disable 0649
		private Color _CurrentValue;
#pragma warning restore 0649
		/// <summary>
		/// Current value of the lerp.
		/// </summary>
		public override Color CurrentValue { get { return _CurrentValue; } }

		[SerializeField]
#pragma warning disable 0649
		private Color _StartingValue;
#pragma warning restore 0649
		/// <summary>
		/// Starting value from which the lerp begins from.
		/// </summary>
		public override Color StartingValue { get { return _StartingValue; } }

		[SerializeField]
#pragma warning disable 0649
		private Color _TargetValue;
#pragma warning restore 0649
		/// <summary>
		/// Target end value for the lerp.
		/// </summary>
		public override Color TargetValue { get { return _StartingValue; } }

		protected override Color ComputeNextLerpValue()
		{
			_CurrentValue = Color.Lerp(_StartingValue, _TargetValue, this.lerpTimerService.timePassedDelta / this.lerpTimerService.TimeInterval);
			return this.CurrentValue;
		}
	}
}
