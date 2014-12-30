using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class position : MonoBehaviour {

	public bool A, B, C, D, E, Taken;
	public GameController cont;
	public string player;
	public Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
	public bool free = false;

	// Each piece has binary value attributed to variables as well as a position on the board (x,y)
	// Positions will help determine the variable values 
	
	public position(bool Aa = false, bool Bb = false, bool Cc = false, bool Dd = false, bool Ee = false, bool take = false) {
		A = Aa;
		B = Bb;
		C = Cc;
		D = Dd;
		E = Ee;
		Taken = take;
	}

	// Use this for initialization
	void Start () {
		cont = (GameController)(GameObject.Find("Camera").GetComponent("GameController"));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		// Select pieces, change to 1 or 0
		if (cont.octet == false && cont.unusedPieces.Count != 0){
			if (cont.currentUser == "P1"){
				if (cont.unusedPieces.ContainsKey(this.gameObject.name)){	
					this.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
					this.gameObject.AddComponent("TextMesh");
					GetComponent<TextMesh>().text = "1";
					GetComponent<TextMesh>().fontSize = 50;
					GetComponent<TextMesh>().font = ArialFont;
					GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
					GetComponent<TextMesh>().renderer.material = ((Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf")).material;
					cont.P1pos.Add(this.gameObject);
					cont.unusedPieces.Remove(this.gameObject.name);
					cont.currentUser = "P2";
				}
			}
			else if (cont.currentUser == "P2"){
				if (cont.unusedPieces.ContainsKey(this.gameObject.name)){
					this.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
					this.gameObject.AddComponent("TextMesh");
					GetComponent<TextMesh>().text = "0";
					GetComponent<TextMesh>().fontSize = 50;
					GetComponent<TextMesh>().font = ArialFont;
					GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
					GetComponent<TextMesh>().renderer.material = ((Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf")).material;
					cont.P2pos.Add(this.gameObject);
					cont.unusedPieces.Remove(this.gameObject.name);
					cont.currentUser = "P1";
				}
			}
		}	
		// Unused positions is empty so it begins counting quads
		else if (cont.octet == false && cont.doubles == false && cont.unusedPieces.Count == 0) {
			if (cont.currentUser == "P1"){
				// List of positions to be used in quad
				// When four positions chosen, checks if valid, changes color accordingly
				if (cont.P1pos.Contains(this.gameObject) && !(cont.quadPos.Contains(this.gameObject))){
					if (cont.quadPos.Count != 3){
						cont.quadPos.Add(this.gameObject);
						GetComponent<TextMesh>().color = Color.red;
					}
					else if (cont.quadPos.Count == 3){
						cont.quadPos.Add(this.gameObject);
						for (int i = 0; i < 4; i++){
							if (((position)cont.quadPos[i].GetComponent("position")).Taken == false) cont.freeQuad = true;
						}
						if (cont.freeQuad && Valid(cont.quadPos)){
							for (int i = 0; i < 4; i++){
								cont.quadPos[i].GetComponent<TextMesh>().color = Color.black;
								((position)cont.quadPos[i].GetComponent("position")).Taken = true;
							}
							cont.P1quads++;
							cont.freeQuad = false;
						}
						else {
							for (int i = 0; i < 4; i++){
								if (((position)cont.quadPos[i].GetComponent("position")).Taken == false){
									cont.quadPos[i].GetComponent<TextMesh>().color = Color.white;
								}
								else {
									cont.quadPos[i].GetComponent<TextMesh>().color = Color.black;	
								}
							}
						}
						cont.quadPos.Clear();
					}
				}
			}
			else if (cont.currentUser == "P2"){
				// List of positions to be used in quad
				// When four positions chosen, checks if valid, changes color accordingly
				if (cont.P2pos.Contains(this.gameObject) && !(cont.quadPos.Contains(this.gameObject))){
					if (cont.quadPos.Count != 3){
						cont.quadPos.Add(this.gameObject);
						GetComponent<TextMesh>().color = Color.red;
					}
					else if (cont.quadPos.Count == 3){
						cont.quadPos.Add(this.gameObject);
						for (int i = 0; i < 4; i++){
							if (((position)cont.quadPos[i].GetComponent("position")).Taken == false) cont.freeQuad = true;
						}
						if (cont.freeQuad && Valid(cont.quadPos)){
							for (int i = 0; i < 4; i++){
								cont.quadPos[i].GetComponent<TextMesh>().color = Color.black;
								((position)cont.quadPos[i].GetComponent("position")).Taken = true;
							}
							cont.P2quads++;
							cont.freeQuad = false;
						}
						else {
							for (int i = 0; i < 4; i++){
								if (((position)cont.quadPos[i].GetComponent("position")).Taken == false){
									cont.quadPos[i].GetComponent<TextMesh>().color = Color.white;
								}
								else {
									cont.quadPos[i].GetComponent<TextMesh>().color = Color.black;	
								}
							}
						}
						cont.quadPos.Clear();
					}
				}
			}
		}
		// Octet is active
		else if (cont.octet == true) {
			if (cont.currentUser == "P1"){
				if (cont.P1pos.Contains(this.gameObject) && !(cont.octetPos.Contains(this.gameObject))){
					if (cont.octetPos.Count != 7){
						cont.octetPos.Add(this.gameObject);
						GetComponent<TextMesh>().color = Color.red;
					}
					else {
						cont.octetPos.Add(this.gameObject);
						if (octetValid(cont.octetPos)); //load end game for octet
						else {
							for (int i = 0; i < 8 ; i++){
								cont.octetPos[i].GetComponent<TextMesh>().color = Color.white;
							}
							cont.octetPos.Clear();
							cont.octet = false;
						} //return to game
					}
				}
			}
			else if (cont.currentUser == "P2"){
				if (cont.P2pos.Contains(this.gameObject) && !(cont.octetPos.Contains(this.gameObject))){
					if (cont.octetPos.Count != 7){
						cont.octetPos.Add(this.gameObject);
						GetComponent<TextMesh>().color = Color.red;
					}
					else {
						cont.octetPos.Add(this.gameObject);
						if (octetValid(cont.octetPos)); //load end game for octet
						else{
							for (int i = 0; i < 8 ; i++){
								cont.octetPos[i].GetComponent<TextMesh>().color = Color.white;
							}
							cont.octetPos.Clear();
							cont.octet = false;
						} //return to game
					}
				}
			}
		}

		// Done counting quads and have even number, need to count doubles
		else if (cont.doubles == true){
			if (cont.currentUser == "P1"){
				// List of two positions to be used in doubles
				// When two positions chosen, checks if valid, changes color accordingly
				if (cont.P1pos.Contains(this.gameObject) && !(cont.doublePos.Contains(this.gameObject))){
					if (cont.doublePos.Count == 0){
						cont.doublePos.Add(this.gameObject);
						GetComponent<TextMesh>().color = Color.red;
					}
					else if (cont.doublePos.Count == 1){
						cont.doublePos.Add(this.gameObject);
						for (int i = 0; i < 2; i++){
							if (((position)cont.doublePos[i].GetComponent("position")).Taken == false) cont.freeDouble = true;
						}
						if (cont.freeDouble && doubleValid(cont.doublePos)){
							for (int i = 0; i < 2; i++){
								cont.doublePos[i].GetComponent<TextMesh>().color = Color.black;
								((position)cont.doublePos[i].GetComponent("position")).Taken = true;
							}
							cont.P1doubles++;
							cont.freeDouble = false;
						}
						else {
							for (int i = 0; i < 2; i++){
								if (((position)cont.doublePos[i].GetComponent("position")).Taken == false){
									cont.doublePos[i].GetComponent<TextMesh>().color = Color.white;
								}
								else {
									cont.doublePos[i].GetComponent<TextMesh>().color = Color.black;	
								}
							}
						}
						cont.doublePos.Clear();
					}
				}
			}

			else if (cont.currentUser == "P2"){
				// List of two positions to be used in doubles
				// When two positions chosen, checks if valid, changes color accordingly
				if (cont.P2pos.Contains(this.gameObject) && !(cont.doublePos.Contains(this.gameObject))){
					if (cont.doublePos.Count == 0){
						cont.doublePos.Add(this.gameObject);
						GetComponent<TextMesh>().color = Color.red;
					}
					else if (cont.doublePos.Count == 1){
						cont.doublePos.Add(this.gameObject);
						for (int i = 0; i < 2; i++){
							if (((position)cont.doublePos[i].GetComponent("position")).Taken == false) cont.freeDouble = true;
						}
						if (cont.freeDouble && doubleValid(cont.doublePos)){
							for (int i = 0; i < 2; i++){
								cont.doublePos[i].GetComponent<TextMesh>().color = Color.black;
								((position)cont.doublePos[i].GetComponent("position")).Taken = true;
							}
							cont.P2doubles++;
							cont.freeDouble = false;
						}
						else {
							for (int i = 0; i < 2; i++){
								if (((position)cont.doublePos[i].GetComponent("position")).Taken == false){
									cont.doublePos[i].GetComponent<TextMesh>().color = Color.white;
								}
								else {
									cont.doublePos[i].GetComponent<TextMesh>().color = Color.black;	
								}
							}
						}
						cont.doublePos.Clear();
					}
				}
			}
		}
	}

	// Finds if the four selected pieces have at least three variables in common (to make a valid quad)
	bool Valid(List<GameObject> selected) {
		int sharedVar = 0;
		if ((((position)selected[0].GetComponent("position")).A == ((position)selected[1].GetComponent("position")).A) && (((position)selected[1].GetComponent("position")).A == ((position)selected[2].GetComponent("position")).A) && (((position)selected[2].GetComponent("position")).A == ((position)selected[3].GetComponent("position")).A)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).B == ((position)selected[1].GetComponent("position")).B) && (((position)selected[1].GetComponent("position")).B == ((position)selected[2].GetComponent("position")).B) && (((position)selected[2].GetComponent("position")).B == ((position)selected[3].GetComponent("position")).B)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).C == ((position)selected[1].GetComponent("position")).C) && (((position)selected[1].GetComponent("position")).C == ((position)selected[2].GetComponent("position")).C) && (((position)selected[2].GetComponent("position")).C == ((position)selected[3].GetComponent("position")).C)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).D == ((position)selected[1].GetComponent("position")).D) && (((position)selected[1].GetComponent("position")).D == ((position)selected[2].GetComponent("position")).D) && (((position)selected[2].GetComponent("position")).D == ((position)selected[3].GetComponent("position")).D)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).E == ((position)selected[1].GetComponent("position")).E) && (((position)selected[1].GetComponent("position")).E == ((position)selected[2].GetComponent("position")).E) && (((position)selected[2].GetComponent("position")).E == ((position)selected[3].GetComponent("position")).E)) sharedVar++;
		Debug.Log(sharedVar);
		return (sharedVar == 3);
	}

	bool octetValid(List<GameObject> selected){
		int sharedVar = 0;
		if ((((position)selected[0].GetComponent("position")).A == ((position)selected[1].GetComponent("position")).A) && (((position)selected[1].GetComponent("position")).A == ((position)selected[2].GetComponent("position")).A) && (((position)selected[2].GetComponent("position")).A == ((position)selected[3].GetComponent("position")).A) && (((position)selected[3].GetComponent("position")).A == ((position)selected[4].GetComponent("position")).A) && (((position)selected[4].GetComponent("position")).A == ((position)selected[5].GetComponent("position")).A) && (((position)selected[5].GetComponent("position")).A == ((position)selected[6].GetComponent("position")).A) && (((position)selected[6].GetComponent("position")).A == ((position)selected[7].GetComponent("position")).A)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).B == ((position)selected[1].GetComponent("position")).B) && (((position)selected[1].GetComponent("position")).B == ((position)selected[2].GetComponent("position")).B) && (((position)selected[2].GetComponent("position")).B == ((position)selected[3].GetComponent("position")).B) && (((position)selected[3].GetComponent("position")).B == ((position)selected[4].GetComponent("position")).B) && (((position)selected[4].GetComponent("position")).B == ((position)selected[5].GetComponent("position")).B) && (((position)selected[5].GetComponent("position")).B == ((position)selected[6].GetComponent("position")).B) && (((position)selected[6].GetComponent("position")).B == ((position)selected[7].GetComponent("position")).B)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).C == ((position)selected[1].GetComponent("position")).C) && (((position)selected[1].GetComponent("position")).C == ((position)selected[2].GetComponent("position")).C) && (((position)selected[2].GetComponent("position")).C == ((position)selected[3].GetComponent("position")).C) && (((position)selected[3].GetComponent("position")).C == ((position)selected[4].GetComponent("position")).C) && (((position)selected[4].GetComponent("position")).C == ((position)selected[5].GetComponent("position")).C) && (((position)selected[5].GetComponent("position")).C == ((position)selected[6].GetComponent("position")).C) && (((position)selected[6].GetComponent("position")).C == ((position)selected[7].GetComponent("position")).C)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).D == ((position)selected[1].GetComponent("position")).D) && (((position)selected[1].GetComponent("position")).D == ((position)selected[2].GetComponent("position")).D) && (((position)selected[2].GetComponent("position")).D == ((position)selected[3].GetComponent("position")).D) && (((position)selected[3].GetComponent("position")).D == ((position)selected[4].GetComponent("position")).D) && (((position)selected[4].GetComponent("position")).D == ((position)selected[5].GetComponent("position")).D) && (((position)selected[5].GetComponent("position")).D == ((position)selected[6].GetComponent("position")).D) && (((position)selected[6].GetComponent("position")).D == ((position)selected[7].GetComponent("position")).D)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).E == ((position)selected[1].GetComponent("position")).E) && (((position)selected[1].GetComponent("position")).E == ((position)selected[2].GetComponent("position")).E) && (((position)selected[2].GetComponent("position")).E == ((position)selected[3].GetComponent("position")).E) && (((position)selected[3].GetComponent("position")).E == ((position)selected[4].GetComponent("position")).E) && (((position)selected[4].GetComponent("position")).E == ((position)selected[5].GetComponent("position")).E) && (((position)selected[5].GetComponent("position")).E == ((position)selected[6].GetComponent("position")).E) && (((position)selected[6].GetComponent("position")).E == ((position)selected[7].GetComponent("position")).E)) sharedVar++;
		Debug.Log(sharedVar);
		return (sharedVar == 2);
	}

	bool doubleValid(List<GameObject> selected){
		int sharedVar = 0;
		Debug.Log(selected.Count);
		if ((((position)selected[0].GetComponent("position")).A == ((position)selected[1].GetComponent("position")).A)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).B == ((position)selected[1].GetComponent("position")).B)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).C == ((position)selected[1].GetComponent("position")).C)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).D == ((position)selected[1].GetComponent("position")).D)) sharedVar++;
		if ((((position)selected[0].GetComponent("position")).E == ((position)selected[1].GetComponent("position")).E)) sharedVar++;
		Debug.Log(sharedVar);
		return (sharedVar == 4);
	}

	// For drawing buttons when switching players during quad counting
	void OnGUI() {
		if (cont.unusedPieces.Count != 0){
			// Octet shows up when both players have made at least eight moves.
			if (cont.P2pos.Count > 7){
				if (GUI.Button(new Rect(375, 280, 150, 30), "Octet")) cont.octet = true;
			}
		}

		if (cont.unusedPieces.Count == 0){
			if (cont.doubles == false){
				GUI.Label(new Rect(200, 85, 200, 20), "Player 1 Quads:" + cont.P1quads);
				GUI.Label(new Rect(580, 85, 200, 20), "Player 2 Quads:" + cont.P2quads);
		
				if (cont.currentUser == "P1"){
					if (GUI.Button(new Rect(375, 280, 150, 30), "Player 1 Done")) cont.currentUser = "P2";
				}
				else if (cont.currentUser == "P2"){
					if (GUI.Button(new Rect(375, 280, 150, 30), "Player 2 Done")){
						if (cont.P1quads == cont.P2quads) {
							cont.doubles = true;
							cont.currentUser = "P1";
						}
						else; //load end scene
					} 
				}
			}

			else if (cont.doubles == true){
				GUI.Label(new Rect(200, 85, 200, 20), "Player 1 Doubles:" + cont.P1doubles);
				GUI.Label(new Rect(580, 85, 200, 20), "Player 2 Doubles:" + cont.P2doubles);

				if (cont.currentUser == "P1"){
					if (GUI.Button(new Rect(375, 280, 150, 30), "Player 1 Done")) cont.currentUser = "P2";
				}
				else if (cont.currentUser == "P2"){
					if (GUI.Button(new Rect(375, 280, 150, 30), "Player 2 Done")){
						if (cont.P1doubles == cont.P2doubles); // load tie end game
						else; //load end scene
					} 
				}
			}
		}
	}
}
