using UnityEngine;
using System.Collections;

public class InstructionMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width/2 - 62, Screen.height/2 - 95, 125, 30), "What Are K-Maps?")) Application.LoadLevel("kmapInfo");
		if (GUI.Button(new Rect(Screen.width/2 - 62, Screen.height/2 - 30, 125, 30), "How To Play")) Application.LoadLevel("howTo");
		if (GUI.Button(new Rect(Screen.width/2 - 62, Screen.height - 130, 125, 30), "Back to Main")) Application.LoadLevel("start");
	}
}
