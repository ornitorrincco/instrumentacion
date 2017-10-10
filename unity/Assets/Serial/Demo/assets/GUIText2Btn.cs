﻿/** Use this script on a GUIText gameObject, acting as a placholder, to transform it at runtime into a Button.
 * Configure the action(s) for the click event and you have an easy way to setup an interface
 * visually by placing elements on a screen.
 * 
 * Pierre Rossel, 2014-01-24
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GUIText2Btn : MonoBehaviour
{

	public string onClickLoadScene;
	public string onClickSendMessage;
	public string onClickBroadcastMessage;
	public string onClickSendMessageUpwards;
	public GameObject MessageTarget;

	void OnGUI ()
	{
		GUIStyle guiStyle = new GUIStyle ("button");

		// Get as much style as possible from placeholder GUIText
		guiStyle.fontStyle = gameObject.GetComponent<GUIText>().fontStyle;
		guiStyle.font = gameObject.GetComponent<GUIText>().font; 
		guiStyle.fontSize = gameObject.GetComponent<GUIText>().fontSize; 
		guiStyle.margin = new RectOffset (10, 10, 10, 10);

		GUI.color = gameObject.GetComponent<GUIText>().color;

		// Size the button
		Rect rect = gameObject.GetComponent<GUIText>().GetScreenRect ();

		rect.y = Screen.height - rect.y - rect.height;
		//rect.x += 200;

		rect.x -= 10;
		rect.y -= 10;
		rect.width += 20;
		rect.height += 20;

		if (GUI.Button (rect, gameObject.GetComponent<GUIText>().text, guiStyle)) {
			if (onClickLoadScene != null)
				SceneManager.LoadScene (onClickLoadScene);

			GameObject target = MessageTarget;
			if (target == null)
				target = gameObject;

			if (onClickSendMessage != "")
				target.SendMessage (onClickSendMessage, this);
			if (onClickBroadcastMessage != "")
				target.BroadcastMessage (onClickBroadcastMessage, this);
			if (onClickSendMessageUpwards != "")
				target.SendMessageUpwards (onClickSendMessageUpwards, this);
		}
	}
}
