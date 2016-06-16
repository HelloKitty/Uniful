using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Uniful
{
	/// <summary>
	/// Exposes Unity3D API query for audio state changing through event-based 
	/// callbacks using <see cref="UnityEngine.Events.UnityEvent"/>.
	/// </summary>
	[RequireComponent(typeof(AudioSource))]
	public class OnAudioStoppedPlaying : MonoBehaviour
	{
#pragma warning disable 0649
		[SerializeField]
		private bool shouldDestroyOnFire;
#pragma warning restore 0649

		/// <summary>
		/// Exposes a callback list for subscribers to listen for when the <see cref="AudioSource"/> stops playing.
		/// </summary>
		[SerializeField]
		private UnityEvent OnAudioStoppedPlayingEvent;

		/// <summary>
		/// Internally tracked <see cref="AudioSource"/> component.
		/// </summary>
		private AudioSource AudioSourceComponent;

		private void Awake()
		{
			//Can't be null since we require the component
			AudioSourceComponent = GetComponent<AudioSource>();
		}

		private void FixedUpdate()
		{
			if(!AudioSourceComponent.isPlaying)
			{
				if(OnAudioStoppedPlayingEvent != null)
					OnAudioStoppedPlayingEvent.Invoke();

				//user indicates if the component should be destroyed (costly and may want to be avoided)
				//otherwise we disable the update.
				if (shouldDestroyOnFire)
					Destroy(this);
				else
					enabled = false;
			}

		}
	}
}
