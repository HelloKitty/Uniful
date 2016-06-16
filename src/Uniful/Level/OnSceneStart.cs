using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Uniful
{
	/// <summary>
	/// Exposes Unity3D API <see cref="Start"/> magic method to the inspector and offers
	/// callbacks using <see cref="UnityEngine.Events.UnityEvent"/>.
	/// </summary>
	public class OnSceneStart : MonoBehaviour
	{
		/// <summary>
		/// Exposes a callback list for subscribers to listen for when the the current scene begins.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private UnityEvent OnSceneStartEvent;
#pragma warning restore 0649

		void Start()
		{
			if (OnSceneStartEvent != null)
				OnSceneStartEvent.Invoke();
		}
	}
}
