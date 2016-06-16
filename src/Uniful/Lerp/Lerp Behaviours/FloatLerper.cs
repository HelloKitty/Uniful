using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Tasks
{
	/// <summary>
	/// A helper component that abstracts the Lerping process and brings it from a code concept to an configurable
	/// inspector exposed concept to designers.
	/// </summary>
	public class FloatLerper : LerperBehaviour
	{
		/// <summary>
		/// This allows us to serialize a UnityEvent`T and send the float value to a callback.
		/// </summary>
		[Serializable]
		public class OnFloatChanged : UnityEvent<float> { }

		[SerializeField]
		private OnFloatChanged _OnFloatChangeCallback = new OnFloatChanged();
		/// <summary>
		/// A delegate that will be invoked when the float value for the Lerper changes.
		/// </summary>
		public OnFloatChanged OnFloatChangeCallback
		{
			get { return _OnFloatChangeCallback; }
		}

		/// <summary>
		/// Current float value as a result of the lerper.
		/// </summary>
		public float CurrentValue
		{
			get { return LerpOptions.CurrentValue; }
		}

		[SerializeField]
		private LerpTaskFloat LerpOptions;
		/// <summary>
		/// A container for options that are configurable in the editor for the lerping process.
		/// </summary>
		protected override LerpTask LerpTaskOptions
		{
			get { return LerpOptions; }
		}

		/// <summary>
		/// Provides a code-based initialization method for the <see cref="LerpTask"/> options if created via code.
		/// </summary>
		/// <param name="start">The starting value of the float lerp process.</param>
		/// <param name="finish">The finishing value of the float for the lerp process.</param>
		/// <param name="interval">The interval/duration for which the lerp process should continue to linerally increase the value.</param>
		public void Init(float start, float finish, float interval, bool destroyOnFinish = false)
		{
			this._DeactivateOnFinished = destroyOnFinish;
			LerpOptions = new LerpTaskFloat(start, finish, interval);
		}

		/// <summary>
		/// Is called in the base class and should implement the <see cref="Type"/> specific lerping process. Generally just called Lerp on the LerpTask
		/// And passes it to the listeners.
		/// </summary>
		protected override void LerpLogic()
		{
			OnFloatChangeCallback.Invoke(LerpOptions.Lerp());
		}
	}
}
