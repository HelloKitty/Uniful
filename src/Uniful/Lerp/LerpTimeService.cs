using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uniful
{
	/// <summary>
	/// Timer service for lerps that take input for timing setup and tick time forward when requested.
	/// </summary>
	[Serializable]
	public class LerpTimeService
	{
		/// <summary>
		/// Indicates of the LerpTimer has completed.
		/// </summary>
		public bool Finished { get; protected set; }

		[SerializeField]
		private float _TimeInterval;
		/// <summary>
		/// The duration of the Lerp event.
		/// </summary>
		public float TimeInterval
		{
			get { return _TimeInterval; }

			//TODO: Property's shouldn't throw exceptions but we SHOULD make sure this doesn't happen during Lerping.
			protected set
			{
				this._TimeInterval = value;
			}
		}

		/// <summary>
		/// Indicates how much time has passed since the Lerping process has begun.
		/// </summary>
		public float timePassedDelta { get; private set; }

		public LerpTimeService()
		{
			Finished = false;
			timePassedDelta = 0;
		}

		/// <summary>
		/// Steps time forward using Unity3D's <see cref="Time"/> class' delaTime static property and
		/// sets Finished if enough time has passed to satisfy the <see cref="TimeInterval"/>'s duration.
		/// </summary>
		public virtual void StepTimeForward()
		{
			timePassedDelta += Time.deltaTime;
			Finished = timePassedDelta >= TimeInterval;
		}
	}
}
