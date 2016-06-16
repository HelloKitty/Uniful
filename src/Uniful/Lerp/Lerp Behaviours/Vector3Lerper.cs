using Assets.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Task
{
	public class Vector3Lerper : LerperBehaviour
	{
		[Serializable]
		public class OnValueChanged : UnityEvent<Vector3> { }

		public OnValueChanged OnValueChange;

		[SerializeField]
		private LerpTaskVector3 _LerpOptions;
		protected override LerpTask LerpTaskOptions
		{
			get { return _LerpOptions; }
		}

		protected override void LerpLogic()
		{
			this.OnValueChange.Invoke(_LerpOptions.Lerp());
		}
	}
}
