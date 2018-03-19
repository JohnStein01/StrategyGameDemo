using UnityEngine;
using System.Collections;

public class GridEditor : MonoBehaviour {

	public float cell_size = 0.32f; 
	private float x, y;

	void Start() {
		x = 0f;
		y = 0f;
	} 

	void Update () {
		
		if ((this.gameObject.name == "Infantry")||(this.gameObject.name == "Infantry(Clone)")) {
			int i = Pathfinder.CheckLoc (transform.position);
			transform.position = Pathfinder.NodeList [i].Location;
		}

		else if((this.gameObject.name == "Barracks")||(this.gameObject.name == "Barracks(Clone)")) {			
		x = Mathf.Round(transform.position.x / cell_size) * cell_size;
		y = Mathf.Round(transform.position.y / cell_size) * cell_size;	
		transform.position = new Vector2(x, y);		
		}

		else{
		x = Mathf.Round(transform.position.x / cell_size) * cell_size;
			int i = Pathfinder.CheckLoc (transform.position);
			Vector2 Loc = Pathfinder.NodeList [i].Location;
			transform.position = new Vector2(x, Loc.y);		
		}
}

}