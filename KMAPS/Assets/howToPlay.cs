using UnityEngine;
using System.Collections;

public class howToPlay : MonoBehaviour {

	public bool pageOne = true;
	public bool pageTwo = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 14;
		style.normal.textColor = Color.white;

		if (pageOne){
			GUI.Label(new Rect(20, 20, 300, 30), "This section will only tell you information for this specific game. If ", style);
			GUI.Label(new Rect(20, 45, 300, 30), "you do not understand K-Maps, please visit the 'What are K-Maps?' Section.", style);
			GUI.Label(new Rect(20, 70, 300, 30), "The goal of this game is to win in one of three ways: making an octet during", style);
			GUI.Label(new Rect(20, 95, 300, 30), "the game, having the most quads when counting, or, if quads are tied, having", style);
			GUI.Label(new Rect(20, 120, 300, 30), "the most doubles left over. Players take turns placing 1s or 0s, 1s always go", style);
	        GUI.Label(new Rect(20, 145, 300, 30), "first. (You may flip a coin to decide which player is 1.) When the octet option", style);
	        GUI.Label(new Rect(20, 170, 300, 30), "is available, if you think you have eight squares that will make an octet, click", style);
	        GUI.Label(new Rect(20, 195, 300, 30), "the octet button on your turn, followed by your squares. The squares you select", style);
	        GUI.Label(new Rect(20, 220, 300, 30), "will turn red. You may click the octet button again to return to the game at any ", style);
	        GUI.Label(new Rect(20, 245, 300, 30), "time. If you have not made an octet with those squares, they will become white", style);
	        GUI.Label(new Rect(20, 270, 300, 30), "again and the game will resume. If you have made an octet, you win! If no one", style);
	        if (GUI.Button(new Rect(380, 295, 125, 25), "Next")) {
	        	pageOne = false;
	        	pageTwo = true;
	        }
	    }
	    else if (pageTwo){
			GUI.Label(new Rect(20, 20, 300, 30), "makes an octet during the game, then after all the squares are used players", style);
			GUI.Label(new Rect(20, 45, 300, 30), "will count their quads. Whoever went first counts first. To mark a quad, ", style);
			GUI.Label(new Rect(20, 70, 300, 30), "click on all four chosen squares. As you select, they will turn red, and if", style);
			GUI.Label(new Rect(20, 95, 300, 30), "the quad is valid, all four squares will become black and those spots will be", style);
			GUI.Label(new Rect(20, 120, 300, 30), "'taken'. If you spot an original quad but all four of its squares have been", style);
	        GUI.Label(new Rect(20, 145, 300, 30), "taken, you may no longer use that quad. Once player one finishes counting", style);
	        GUI.Label(new Rect(20, 170, 300, 30), "all quads, click 'Player 1 Done' and player two will then choose quads. If ", style);
	        GUI.Label(new Rect(20, 195, 300, 30), "after both players are done they have an equal amount of quads, doubles will", style);
	        GUI.Label(new Rect(20, 220, 300, 30), "be counted the same way. If both doubles and quads are tied, the game ends ", style);
	        GUI.Label(new Rect(20, 245, 300, 30), "in a tie, and you'll have to play again!", style);
	        if (GUI.Button(new Rect(250, 295, 125, 25), "Previous")) {
	        	pageOne = true;
	        	pageTwo = false;
	        }
	    }
        if (GUI.Button(new Rect(20, 295, 125, 25), "Back to Info")) Application.LoadLevel("instructions");
	}
}
