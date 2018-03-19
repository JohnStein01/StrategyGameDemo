using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Availability : MonoBehaviour {
	
	public bool isInside;

	void Start () {
		isInside = false;
	}

	// Check if the buildings are inside the map area
	void Update () {
		
		if ((name == "Barracks"||name == "Barracks(Clone)")){
			if ((this.gameObject.transform.position.x < 1.28f) && (this.gameObject.transform.position.y < 1.65f)
			    && (this.gameObject.transform.position.x > -1.28f) && (this.gameObject.transform.position.y > -1.65f)) {
				isInside = true;
		} else				
				isInside = false;
		} else if (name == "Power Plant"||name == "Power Plant(Clone)") {	
			if ((this.gameObject.transform.position.x < 1.35f) && (this.gameObject.transform.position.y < 1.80f)
			    && (this.gameObject.transform.position.x > -1.35f) && (this.gameObject.transform.position.y > -1.80f)) {
				isInside = true;			
			} else
				isInside = false;
		} 	
	}

	void OnTriggerEnter(Collider other){		
		if (other.gameObject.name != "Grass")
			Build.penetration = false;	
	}

	//Check if the building collides with another
	void OnTriggerStay(Collider other){
		if ((other.gameObject.name != "Grass")&&(other.gameObject.activeInHierarchy)
			&&(other.bounds.size.x/2+other.bounds.center.x>this.gameObject.transform.position.x)
			&&(other.bounds.size.y/2+other.bounds.center.y>this.gameObject.transform.position.y)
			&&(other.bounds.center.x-other.bounds.size.x/2<this.gameObject.transform.position.x)
			&&(other.bounds.center.y-other.bounds.size.y/2<this.gameObject.transform.position.y))
			Build.penetration = true;
	}	

	void OnTriggerExit(Collider other){
		if (other.gameObject.name != "Grass")
			Build.penetration = false;		
	}

	void OnMouseDown(){
		UnitInfo.BuildingSelected = this.gameObject.name;
		TrainSoldier.SpawnPoint = this.transform.position-new Vector3(0.48f, 0.80f,0);
	}
}
