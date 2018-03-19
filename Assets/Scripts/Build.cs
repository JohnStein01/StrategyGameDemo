using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Build : MonoBehaviour {
	public GameObject building;
	public Button button;
	private bool clickedOn;
	private GameObject buildingClone;
	public static bool penetration;
	public float clickTimer;
	//Start the bulding process OnButtonClick
	void Start () {		
		building.SetActive (false);
		clickedOn = false;
		penetration = false;
		Button btn = button.GetComponent<Button> ();
		btn.onClick.AddListener(OnButtonClick);		
		clickTimer = 0;
	}

	//Enable, move and place the building with a double click if there is no other penetrating object entering the area
	void Update () {		
		
		if (clickedOn) {			
			Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouseWorldPoint.z = 0f;
			building.transform.position = mouseWorldPoint;

			if (penetration) {
				building.GetComponent<SpriteRenderer> ().color = Color.red;
			}

			else {
				building.GetComponent<SpriteRenderer> ().color = Color.white;					 

				if ((Input.GetMouseButton (0))&&(building.GetComponent<Availability>().isInside)) {					

					if ((Time.realtimeSinceStartup-clickTimer > 0.05f)&&(1f>Time.realtimeSinceStartup-clickTimer)) {						
						clickTimer = 0;
						clickedOn = false;
						Pathfinder.ButtonBusy = false;
						Placed ();
					}

					else {
						clickTimer = Time.realtimeSinceStartup;
					}
				}
			}
		}
	}

	//Create the building
	void OnButtonClick () {
		
		if(!Pathfinder.ButtonBusy){
		Pathfinder.ButtonBusy = true;
		if (!building.activeInHierarchy)
			building.SetActive(true);
		
		else
		buildingClone = Instantiate (building) as GameObject;
		
		clickedOn = true;
	}
	}

	//Place the building
//	void OnMouseDown () {		
//		clickedOn = false;
//	}

	//Set the nodes under the buildings as filled
	void Placed(){

		if (building.gameObject.name == "Barracks" || building.gameObject.name == "Barracks(Clone)") {
			int index = Pathfinder.CheckLoc (building.gameObject.transform.position - new Vector3 (0.48f, 0.48f,0));
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					Pathfinder.NodeList [index + i + 10 * j].Filled = true;
				
				}  
			}
		} else if (building.gameObject.name == "Power Plant" || building.gameObject.name == "Power Plant(Clone)") {	
			int index = Pathfinder.CheckLoc (building.gameObject.transform.position - new Vector3 (0.16f, 0.32f,0));
			for (int i = 0; i < 2; i++) {
				for (int j = 0; j < 3; j++) {
					Pathfinder.NodeList [index + i + 10 * j].Filled = true;
				}
			}
		} 
	}
}