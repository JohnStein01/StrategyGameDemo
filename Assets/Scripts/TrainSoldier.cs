using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainSoldier : MonoBehaviour {

	public Button button;
	public GameObject Infantry;
	public static Vector2 SpawnPoint;
	private Vector2 newSpawnPoint;
	public static int i = 1;
	public static int j = 0;

	void Start () {
		Button btn = button.GetComponent<Button> ();
		btn.onClick.AddListener(OnButtonClick);
	}

	void OnButtonClick(){		
		// Change the spawn point if there is any other object
		i=1;
		j=0;
		newSpawnPoint = SpawnPoint;
		while(Pathfinder.NodeList [Pathfinder.CheckLoc (newSpawnPoint)].Filled){
			newSpawnPoint = SpawnPoint + new Vector2 (0.32f * i, -0.32f * j);
			i++;
			if (i == 4) {
				i = 0;
				j++;				
			}
		}

		// Initiate a new soldier at the spawn point	
		if (!Infantry.gameObject.activeInHierarchy) {			
			Infantry.gameObject.transform.position = newSpawnPoint;
			Infantry.SetActive (true);
		} else				
			Instantiate (Infantry, newSpawnPoint, Quaternion.identity);
}
}
