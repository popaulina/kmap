using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class position : MonoBehaviour {

	public bool A, B, C, D, E, Taken;
	public GameController cont;
	public Rect pos;
	public string player;
	public Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
	public List<GameObject> quadPos;
	// Each piece has binary value attributed to variables as well as a position on the board (x,y)
	// Positions will help determine the variable values 
	
	// public struct Pos {
	// 	public int x, y;
	// 	public Pos(int xx, int yy){
	// 		x = xx;
	// 		y = yy;
	// 	}
	// }
	// public Pos p;

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
		pos = new Rect((this.gameObject.transform.position.x), (this.gameObject.transform.position.y), 100,100);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (cont.unusedPieces.Count != 0){
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

		else {
			
		}
	}

	void quadChoosing(){

	}


}
