using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfo : MonoBehaviour {
	public SpriteRenderer BuildingImage;
	public Button SoldierButton;
	public static string BuildingSelected;
	private Sprite[] BuildingSprites;

	void Start () {					
		SoldierButton.gameObject.SetActive(false);
		BuildingSprites=Resources.LoadAll<Sprite> ("Sprites");	
	}

	// Shows an info screen when a building is selected
	void Update () {
		
		if (BuildingSelected == "Barracks"||BuildingSelected=="Barracks(Clone)") {
			SoldierButton.gameObject.SetActive (true);
			BuildingImage.sprite = BuildingSprites [0];
		} else if (BuildingSelected == "Power Plant"||BuildingSelected == "Power Plant(Clone)") {	
			SoldierButton.gameObject.SetActive(false);		
			BuildingImage.sprite = BuildingSprites[1];		
		} 
	}

}
