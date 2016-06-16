using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Uniful
{
	/// <summary>
	/// Component that exposes event-like functionality for a fake on level loaded event.
	/// </summary>
	public class OnLevelLoad : MonoBehaviour
	{
#if UNITY_EDITOR
#pragma warning disable 0649
		/// <summary>
		/// Bool indicating if we should emulate level loading sematics in editor.
		/// </summary>
		[SerializeField]
		private bool emulateLevelLoadOnEditorPlay;
#pragma warning restore 0649
#endif

		/// <summary>
		/// List of delegates to invoke at the start of the level.
		/// </summary>
		public UnityEvent OnLevelLoaded;

#if UNITY_EDITOR
		void Start()
		{
			//If we're in the editor we need to manually invoke this
			//because OnLevelWasLoaded will not play otherwise.
			if (emulateLevelLoadOnEditorPlay)
				OnLevelLoaded.Invoke();
		}
#endif

		/// <summary>
		/// Unity3D magic method called when a level was loaded.
		/// </summary>
		/// <param name="id">Id of the scene/level loaded.</param>
		void OnLevelWasLoaded(int id)
		{

#if UNITY_EDITOR
			//We check this to see if we already emulated it in Start (or if we plan to, don't remember order)
			//We only need to check this in ecitor though.
			if (!emulateLevelLoadOnEditorPlay)
#endif
				OnLevelLoaded.Invoke();
		}
	}
}
