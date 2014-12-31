using UnityEngine;
using System.Collections;

public class kmap : MonoBehaviour {

	public bool pageOne = true;
	public bool pageTwo = false;
	public bool pageThree = false;

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
		style.alignment = TextAnchor.UpperCenter;

		Texture image = (Texture)Resources.Load("kmapTex", typeof(Texture2D));

        GUI.Label(new Rect(Screen.width/2 - image.width/2, 330, image.width, image.height), image);

		if (pageOne){
			GUI.Label(new Rect(Screen.width/2 - 150, 20, 300, 30), "K-Maps, or Karnaugh Maps, are graphical representations of functions.", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 45, 300, 30), "They are used to quickly simplify long series of functions. This is done", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 70, 300, 30), "through the grouping of 1s and 0s, which show 'minterms' and 'maxterms'.", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 95, 300, 30), "Each minterm and maxterm can be written as a value consisting of variables.", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 120, 300, 30), "The K-Map below is a four variable k-map. Groupings that are made with these", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 145, 300, 30), "maps have to have a number of squares that is a power of two: 2, 4, 8, etc. ", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 173, 300, 30), "We make these groupings by putting together minterms or", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 198, 300, 30), "maxterms that have variables in common. On the image, you", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 223, 300, 30), "can see where the variables map to, A is the bottom two rows,", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 248, 300, 30), "B is the right two columns, etc. Squares that are in the top", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 275, 300, 30), "two rows have A' also known as A prime or 'Not A'.", style);
	        if (GUI.Button(new Rect(Screen.width - 250, 295, 125, 25), "Next")) {
	        	pageOne = false;
	        	pageTwo = true;
	        }
	    }
	    else if (pageTwo){
	    	GUI.Label(new Rect(Screen.width/2 - 150, 20, 300, 30), "Groupings of two squares are called doubles, four squares make a quad, and", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 45, 300, 30), "eight squares make an octet. The more squares that can be grouped together,", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 70, 300, 30), "the better. In order to make an octet, all eight squares must share one variable.", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 95, 300, 30), "For example, if you had minterms in all the squares in the left two columns,", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 120, 300, 30), "you would have an octet where all the minterms shared the variable B'.", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 145, 300, 30), "To make a quad, you need four squares that share two variables. For example,", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 173, 300, 30), "the four squares in the top left corner all share the variables", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 198, 300, 30), "A' and B'. They do not however have C or D in common, ", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 223, 300, 30), "because some squares are in C and some are in C', the", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 248, 300, 30), "same for D and D'. Groupings can be wrapped around the", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 275, 300, 30), "sides and around top and bottom. The corners also make a quad.", style);
	        if (GUI.Button(new Rect(Screen.width - 250, 295, 125, 25), "Next")) {
	        	pageTwo = false;
	        	pageThree = true;
	        }
	        if (GUI.Button(new Rect(Screen.width - 400, 295, 125, 25), "Previous")) {
	        	pageOne = true;
	        	pageTwo = false;
	        }
	    }

	    else if (pageThree){
	    	GUI.Label(new Rect(Screen.width/2 - 150, 20, 300, 30), "The K-Map in this game is a five variable map. It holds two four variable maps", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 45, 300, 30), "just like the one below. With five variables, room needs to be made for E and", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 70, 300, 30), "E'. With the new map, the entire left map is A', the right map is A, and all of the", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 95, 300, 30), "rest of the variables move up one spot. B goes where A is, C to B, D to C,", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 120, 300, 30), "and E replaces D. To figure out how to group among two maps, imagine the", style);
			GUI.Label(new Rect(Screen.width/2 - 150, 145, 300, 30), "maps on top of each other. The same principles remain, groupings are done ", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 173, 300, 30), "with common variables. Now that there five variables, octets", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 198, 300, 30), "require two variables in common, quads need three, doubles", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 223, 300, 30), "need four. The four squares in the top left corner still make a ", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 248, 300, 30), "quad, but now they have A', B', and C' in common. Practice", style);
	        GUI.Label(new Rect(Screen.width/2 - 150, 275, 300, 30), "making groupings with five variable maps, and you'll be pro in no time!", style);
	        if (GUI.Button(new Rect(Screen.width - 400, 295, 125, 25), "Previous")) {
	        	pageTwo = true;
	        	pageThree = false;
	        }
	    }
        if (GUI.Button(new Rect(100, 295, 125, 25), "Back to Info")) Application.LoadLevel("instructions");
	}
}
