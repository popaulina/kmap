using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 25;
		style.normal.textColor = Color.white;

		GUI.Label(new Rect(Screen.width/2 - 145, Screen.height/2 - 75, 300, 30), "Wantowski's K-Map Game!", style);
		if (GUI.Button(new Rect(Screen.width/2 - 62, Screen.height/2 - 25, 125, 30), "Start Game")) Application.LoadLevel("game");
		if (GUI.Button(new Rect(Screen.width/2 - 62, Screen.height/2 + 20, 125, 30), "Instructions")) Application.LoadLevel("instructions"); // load instructions
	}
}
