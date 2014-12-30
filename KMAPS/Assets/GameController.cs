using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Dictionary<string, GameObject> unusedPieces = new Dictionary<string, GameObject>();
	public string currentUser = "P1";
	public List<GameObject> P1pos;
	public List<GameObject> P2pos;
	public List<GameObject> doublePos;
	public List<GameObject> quadPos;
	public List<GameObject> octetPos;
	public int P1quads = 0;
	public int P2quads = 0;
	public int P1doubles = 0;
	public int P2doubles = 0;
	public bool freeQuad = false;
	public bool freeDouble = false;
	public bool octet = false;
	public bool doubles = false;
	public string endGame;
	public bool end = false;

	// Use this for initialization
	void Start () {
		// Drawing the board and putting pieces into a list
		for (int y = 0; y < 4; y++){
			for (int x = 0; x < 4; x++){
				GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Quad);
				piece.AddComponent("BoxCollider");
				Destroy(piece.GetComponent("MeshCollider"));
				piece.collider.isTrigger = true;
				piece.renderer.material.color = Color.grey;
				piece.name = x.ToString() + y.ToString();
				piece.transform.localScale = new Vector3(9f, 9f, 9f);
				piece.transform.position = new Vector3(-34.995f + x*10f, 35.015f - y*10f, -10f);
				piece.AddComponent("position");
				SetVars(x, y, piece);
				unusedPieces.Add(piece.name, piece);
			}
		}
		for (int y = 0; y < 4; y++){
			for (int x = 4; x < 8; x++){
				GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Quad);
				piece.AddComponent("BoxCollider");
				Destroy(piece.GetComponent("MeshCollider"));
				piece.collider.isTrigger = true;
				piece.renderer.material.color = Color.grey;
				piece.name = x.ToString() + y.ToString();
				piece.transform.localScale = new Vector3(9f, 9f, 9f);
				piece.transform.position = new Vector3(15.2f + (x-4)*10f, 35.015f - y*10f, -10f);
				piece.AddComponent("position");
				SetVars(x, y, piece);
				unusedPieces.Add(piece.name, piece);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void End()
	{
		// Clear screen
	}

	// Vars based on kmap setting where A is right map, B is bottom two rows, C is middle two rows,
	// D is right two columns, and E is middle two columns. This may be adjusted for different maps
	// but will yield same results.
	void SetVars(int x, int y, GameObject piece){
		if (x == 4 || x == 5 || x ==6 || x ==7){
			((position)piece.GetComponent("position")).A = true;
		}
		
		if (y == 2 || y == 3){
			((position)piece.GetComponent("position")).B = true;
		}
		if (y == 1 || y ==2){
			((position)piece.GetComponent("position")).C = true;
		}
		if (x == 2 || x == 3 || x==6 || x==7){
			((position)piece.GetComponent("position")).D = true;
		}
		
		if (x == 1 || x == 2 || x == 5 || x ==6){
			((position)piece.GetComponent("position")).E = true;
		}
	}
}
