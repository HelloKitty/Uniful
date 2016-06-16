using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Loading
{
	/// <summary>
	/// Exposes Unity3D API <see cref="Start"/> level loading functionality
	/// which can be used to abstract level loading logic or be the target of <see cref="UnityEngine.Events.UnityEvent"/> callbacks.
	/// </summary>
	public class LoadNewLevel : MonoBehaviour
	{
		/// <summary>
		/// Loads the level/scene with the given id.
		/// </summary>
		/// <param name="id"></param>
		public void LoadLevel(int id)
		{
			//TODO: Change to SceneManager when the likelyhood of someone using a Unity version without it becomes low.
			Application.LoadLevel(id);
		}

		/// <summary>
		/// Loads the level/scene with the specified name.
		/// </summary>
		/// <param name="levelName">Level name.</param>
		public void LoadLevel(string levelName)
		{
			if (String.IsNullOrEmpty(levelName))
				throw new ArgumentException("Cannot load a null or empty named scene/level.", nameof(levelName));

			//TODO: Change to SceneManager when the likelyhood of someone using a Unity version without it becomes low.
			Application.LoadLevel(levelName);
		}
	}
}
