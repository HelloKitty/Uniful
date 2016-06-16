using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Tasks
{
	/// <summary>
	/// Helper class that lerps values and passes them to delegates set in the editor.
	/// </summary>
	public class GraphicColorLerper : LerperBehaviour
	{
		//TODO: When Graphics can be marked with SerializeField follow private/property design.
		[SerializeField]
		private Graphic[] _ToLerp;
		/// <summary>
		/// Collection of referenced graphics to be lerped to the color.
		/// </summary>
		public Graphic[] ToLerp
		{
			get { return _ToLerp; }
		}

		//TODO: If ever needed in code implement a way to initialize options via code.
		[SerializeField]
		private LerpTaskColor LerpOptions;
		protected override LerpTask LerpTaskOptions
		{
			get { return this.LerpOptions; }
		}

		/// <summary>
		/// Lerp logic called in the <see cref="LerperBehaviour"/> base class that implements the grunt logic for lerping color values.
		/// </summary>
		protected override void LerpLogic()
		{
			Color newColor = LerpOptions.Lerp();
			for (int i = 0; i < ToLerp.Length; i++)
				ToLerp[i].color = newColor;
		}
	}
}
