﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGCore
{
	[NodeInformation ("Item/Roll")]
	public class RollNode : BehaviourNode
	{
		public IntInput Min;
		public IntInput Max;

		public IntOutput Output;

		protected override void OnSetup (IBehaviourContext context)
		{
			ConnectionEntry<int> minInput = Min.GetEntry (context);
			ConnectionEntry<int> maxInput = Max.GetEntry (context);
			ConnectionEntry<int> output = Output.GetEntry (context);

			Action updateHandler = () =>
			{
				output.Value = UnityEngine.Random.Range (minInput.Value, maxInput.Value + 1);
			};

			minInput.OnAfterChanged += updateHandler;
			maxInput.OnAfterChanged += updateHandler;

			updateHandler ();
		}

		protected override void OnRemove (IBehaviourContext character)
		{

		}

#if UNITY_EDITOR
		public override Vector2 GetDiamentions ()
		{
			return new Vector2 (140, 54);
		}
#endif
	}
}