using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace Uniful
{
	// Requires that we have an AudioSource in case the movie plays sound
	/// <summary>
	/// Provides a component that can manage a <see cref="MovieTexture"/> in the scene.
	/// </summary>
	[RequireComponent(typeof(AudioSource))]
	public class MovieMaterialManager : MonoBehaviour
	{
		/// <summary>
		/// A collection of keys that can be pressed to skip the video playing.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private KeyCode[] skipKeys;
#pragma warning restore 0649

#if !UNITY_WEBGL
		/// <summary>
		/// The movie texture that we wish to manipulate that will in turn manipulate any material
		/// related to it.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private MovieTexture movieTextureReference;
#pragma warning restore 0649

#endif
		/// <summary>
		/// Indicates that the video should be played immediately.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private bool playImmediately;
#pragma warning restore 0649

		/// <summary>
		/// Indicates if this should be a looping movie texture.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private bool shouldLoop;
#pragma warning restore 0649

		/// <summary>
		/// Indicates if we should play the audiosource attached to the movie texture.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private bool playSound;
#pragma warning restore 0649

		/// <summary>
		/// Indicates if the movie texture playing can be skipped to the end.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private bool canSkip;
#pragma warning restore 0649

		/// <summary>
		/// Collection of listeners that listen for when the video ends.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private UnityEvent onMovieSkipped;
#pragma warning restore 0649

		/// <summary>
		/// Fires when the <see cref="MovieTexture"/> is no longer playing. Will never fire if set to loop.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		private UnityEvent OnFinished;
#pragma warning restore 0649

		void Awake()
		{
#if !UNITY_WEBGL
			movieTextureReference.loop = this.shouldLoop;

			if(playImmediately)
			{
				//Won't be null since we use an attribute to require its existence.
				StartMovie(this.GetComponent<AudioSource>());
			}
#else
			this.OnFinished.Invoke();
#endif
		}

#if !UNITY_WEBGL
		private void FixedUpdate()
		{
			if (canSkip && skipKeys != null && skipKeys.Length > 0)
				foreach (KeyCode kc in skipKeys)
				{
					if (Input.GetKey(kc))
					{
						SkipMovie(this.GetComponent<AudioSource>());
					}
				}

			if (!movieTextureReference.isPlaying && !shouldLoop)
				OnFinished.Invoke();
		}

		/// <summary>
		/// Stops the video. Essentially skipping.
		/// </summary>
		/// <param name="soundSource">The <see cref="AudioSource"/> attached to this GameObject.</param>
		private void SkipMovie(AudioSource soundSource)
		{
			if (movieTextureReference.isPlaying)
			{
				soundSource.Stop();
				movieTextureReference.Stop();


			}
		}

		/// <summary>
		/// Starts the video.
		/// </summary>
		/// <param name="soundSource">The <see cref="AudioSource"/> that, if enabled, will be the source of the texture's sound.</param>
		public void StartMovie(AudioSource soundSource)
		{
			soundSource.clip = movieTextureReference.audioClip;
			movieTextureReference.Play();

			if (playSound)
				soundSource.Play();
		}
#endif
	}
}
