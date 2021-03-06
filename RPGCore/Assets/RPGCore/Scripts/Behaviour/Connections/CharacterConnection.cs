﻿using UnityEngine;
using System;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;

namespace RPGCore
{
	[UnityEditor.CustomPropertyDrawer (typeof (CharacterInput))]
	public partial class InputDrawer { }

	[UnityEditor.CustomPropertyDrawer (typeof (CharacterOutput))]
	[UnityEditor.CustomPropertyDrawer (typeof (CharacterListOutput))]
	public partial class OutputDrawer { }
#endif

	[ConnectionInformation ("Character", "Represents a character")]
	public class CharacterConnection : Connection<RPGCharacter, CharacterConnection, ConnectionEntry<RPGCharacter>>
	{
		public static Color SocketColour = new Color (0.7f, 0.8f, 1.0f);

#if UNITY_EDITOR
		public override void DrawConnection (Vector3 start, Vector3 end, Vector3 startDir, Vector3 endDir)
		{
			float distance = Vector3.Distance (start, end);
			Vector3 startTan = start + (startDir * distance * 0.5f);
			Vector3 endTan = end + (endDir * distance * 0.5f);

			Color connectionColour = new Color (0.8f, 0.95f, 1.0f) * Color.Lerp (GUI.color, Color.white, 0.5f);
			Handles.DrawBezier (start, end, startTan, endTan, connectionColour,
				BehaviourGraphResources.Instance.DefaultTrail, 14);
		}
#endif
	}

	[Serializable]
	public class CharacterInput : CharacterConnection.Input
	{
#if UNITY_EDITOR
		public override void DrawSocket (Rect rect)
		{
			GUI.color = new Color (0.7f, 0.8f, 1.0f) * Color.Lerp (GUI.color, Color.white, 0.5f);
			base.DrawSocket (rect);
			GUI.color = Color.white;
		}
#endif
	}

	[Serializable]
	public class CharacterOutput : CharacterConnection.Output
	{
#if UNITY_EDITOR
		public override void DrawSocket (Rect rect)
		{
			GUI.color = new Color (0.7f, 0.8f, 1.0f) * Color.Lerp (GUI.color, Color.white, 0.5f);
			base.DrawSocket (rect);
			GUI.color = Color.white;
		}
#endif
	}

	[Serializable]
	public class CharacterListOutput : CharacterConnection.ListOutput
	{
#if UNITY_EDITOR
		public override void DrawSocket (Rect rect)
		{
			GUI.color = new Color (0.7f, 0.8f, 1.0f) * Color.Lerp (GUI.color, Color.white, 0.5f);
			base.DrawSocket (rect);
			GUI.color = Color.white;
		}
#endif
	}
}