using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uniful
{
	/// <summary>
	/// Exposes Unity3D API for GameObject transform rotation.
	/// </summary>
	public class RotateGameObject : MonoBehaviour
	{
		/// <summary>
		/// Speed at which to rotate the object.
		/// </summary>
		[SerializeField]
		private float speed;

		/// <summary>
		/// Unit vector direction to rotate the object in.
		/// </summary>
		[SerializeField]
		private Vector3 direction;

		/// <summary>
		/// Indicates if <see cref="FixedUpdate"/> should be used.
		/// If false <see cref="Update"/> is used.
		/// These a magic Unity methods so review that documentation.
		/// </summary>
#pragma warning disable 0649
		[SerializeField]
		protected bool _useFixedUpdate;
#pragma warning restore 0649

		void Update()
		{
			if(!_useFixedUpdate)
				this.gameObject.transform.Rotate(direction * (speed * Time.deltaTime), Space.World);
		}

		void FixedUpdate()
		{
			if(_useFixedUpdate)
				this.gameObject.transform.Rotate(direction * (speed * Time.deltaTime), Space.World);
		}
	}
}
