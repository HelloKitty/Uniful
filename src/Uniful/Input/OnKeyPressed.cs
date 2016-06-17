using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Uniful
{
	/// <summary>
	/// Exposes Unity3D API <see cref="Start"/> OnKeyPressed functionality
	/// which can be used as a simple Input mechanism using event-based <see cref="UnityEngine.Events.UnityEvent"/> callbacks.
	/// </summary>
	public class OnKeyPressed : MonoBehaviour
	{
#pragma warning disable 0649
		[SerializeField]
		private bool shouldDisableOnFire = true;
#pragma warning disable 0649

		/// <summary>
		/// Serializable hack for UnityEvent.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		public class Event : UnityEvent<KeyCode> { }
#pragma warning restore 0649

		/// <summary>
		/// Subscriber list that invokes when the <see cref="Key"/> was pressed.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private Event OnKeyWasPressed;
#pragma warning restore 0649

		/// <summary>
		/// <see cref="KeyCode"/> to listen for.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private KeyCode Key;
#pragma warning restore 0649

		//Check in update
		private void Update()
		{
			if (Input.GetKeyDown(Key))
			{
				if (OnKeyWasPressed != null)
					OnKeyWasPressed.Invoke(Key);

				//If the consumer wants it to be disabled then we just disable the component
				//which stops Update from being called.
				if (shouldDisableOnFire)
					this.enabled = false;
			}
		}
	}
}
