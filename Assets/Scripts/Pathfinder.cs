using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	public static List<Node> NodeList;
	private GameObject NodeClicked;
	public static Node TargetNode;
	public static Node StartingNode;
	public static bool ButtonBusy;
	public static bool SoldierBusy;

	// Initiate Pathfinding variables and objects
	void Start () {
		NodeList=new List<Node>();
		TargetNode = new Node ();
		ButtonBusy = false;
		SoldierBusy = false;
		int x=0; 
		int y=0;

		//Create a Node List of the map
		for(float j = -2.08f; j < 2.09f; j=j+0.32f){			
			for (float i = -1.44f; i < 1.45f; i=i+0.32f) {	
				Node node = new Node ();
				node.Location=new Vector2(i,j);
				node.NodeNum = new Vector2 (x,y);
				node.Filled=false;
				NodeList.Add (node);			
				x++;
			}
			y++;
		}
	}

	//Set the target 
	void OnMouseDown(){
		if (SoldierBusy) {
			Vector3 clickedPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			clickedPosition.z = 0;
			TargetNode = NodeList [CheckLoc (clickedPosition)];
			TargetNode.isSelected = true;
		}
		}		

	//Find the NodeList index of the given location 
	public static int CheckLoc(Vector2 Check){
		int j = 0;

		for (int i = 0; i < NodeList.Count; i++) {
			if ((Check.x - 0.16f < NodeList [i].Location.x) && (Check.x + 0.16f > NodeList [i].Location.x) && (Check.y - 0.16f < NodeList [i].Location.y) && (Check.y + 0.16f > NodeList [i].Location.y))
					j=i;		
		}
		return j;
		}

	//Return the adjacent nodes of a given location as a list of indexes
	public static List<int> CheckNode(Vector2 Check){
		List<int> AdjList = new List<int> ();

		for (int i = 0; i < NodeList.Count; i++) {			
			if ((Check.x - 0.48f < NodeList [i].Location.x) && (Check.x + 0.48f > NodeList [i].Location.x) && (Check.y - 0.48f < NodeList [i].Location.y) && (Check.y + 0.48f > NodeList [i].Location.y))
				AdjList.Add (i);						
		}
		return AdjList;
		}
}
