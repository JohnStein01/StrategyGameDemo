using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;

public class Soldier : MonoBehaviour {

	public bool isSelected;
	public static Vector2 startLoc;
	public Rigidbody rb;
	public GameObject HealthBar;
	private Node CurrentNode;
	private Node PreviousNode;

	//Initiate infantry variables
	void Start() {
		if (this.gameObject.name == "Infantry")
			this.gameObject.SetActive (false);	

		isSelected = false;
		HealthBar.SetActive (false);
		startLoc=this.gameObject.transform.position;
		rb = GetComponent<Rigidbody> ();
	}

	//Check if the soldier and the target point are selected 
	void Update() {
		
		CurrentNode = Pathfinder.NodeList [Pathfinder.CheckLoc (this.gameObject.transform.position)];
		CurrentNode.Filled = true;

		if (Pathfinder.TargetNode.isSelected) {
			if (Pathfinder.TargetNode.NodeNum == CurrentNode.NodeNum) {				
				rb.MovePosition (CurrentNode.Location);
				isSelected = false;
				HealthBar.SetActive (false);
				Pathfinder.TargetNode.isSelected = false;
			}

			if (isSelected) {
				startLoc = this.gameObject.transform.position;
				MovePath ();
			}
		}
	}

	//Select the soldier
	void OnMouseDown(){
		if (!Pathfinder.SoldierBusy) {
			Pathfinder.SoldierBusy = true;
			HealthBar.SetActive (true);
			isSelected = true;
		}
	}

	//Find the way using A* Algorithm and move the infantry
	void MovePath(){
		float gCost,hCost,fCost = 0;
		int nodeIndex = Pathfinder.CheckLoc (startLoc);		  
		Node StartNode= Pathfinder.NodeList[nodeIndex];
		CurrentNode = StartNode;
		List<int> AdjNodes = new List<int> ();
		List<AStarData> AStar = new List<AStarData> ();
		AdjNodes = Pathfinder.CheckNode (StartNode.Location);

		foreach(int node in AdjNodes){
			gCost = Vector3.Distance (StartNode.Location,Pathfinder.NodeList[node].Location);
			hCost=Vector3.Distance (Pathfinder.TargetNode.Location,Pathfinder.NodeList[node].Location);
			fCost = gCost + hCost;
			AStarData a_star = new AStarData ();
			a_star.fcost = fCost;
			a_star.index = node;

			if((StartNode.Location!=Pathfinder.NodeList[node].Location)&&(!Pathfinder.NodeList[node].Filled))
			AStar.Add (a_star);		
			
		}

		AStarData MoveLoc = GetMinNode (AStar);
		Pathfinder.NodeList [Pathfinder.CheckLoc (this.gameObject.transform.position)].Filled = false;	
		Pathfinder.SoldierBusy = false;
		rb.MovePosition(Pathfinder.NodeList [MoveLoc.index].Location);	
	}

	//Get minimum distance
	float GetMin(List<float> list){
		float MinDistance=0;

		for (int i = 0; i < list.Count; i++) {
			if (i == 0) 
				MinDistance=list[i];			

			if((i>0)&&(list[i]<MinDistance))
				MinDistance=list[i];			
		}

		return MinDistance;
	}

	//Get the node with minimum distance
	AStarData GetMinNode(List<AStarData> list){
		float MinDistance=0;
		AStarData AStarMin = new AStarData ();

		for (int i = 0; i < list.Count; i++) {
			if (i == 0) { 
				MinDistance = list [i].fcost;
				AStarMin = list [i];
			}
			if ((i > 0) && (list [i].fcost < MinDistance)) {
				MinDistance = list [i].fcost;
				AStarMin = list [i];
			}
		}

		return AStarMin;
	}
}



