using UnityEngine;
using System.Collections;

public class DrawGizmos: MonoBehaviour{
	//Gizmos with size 0.32 units
	void OnDrawGizmos(){
		for(float j = -2.08f; j < 2.09f; j=j+0.32f){			
		for (float i = -1.44f; i < 1.45f; i=i+0.32f) {			
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireCube (new Vector3 (i, j, 0), new Vector3 (0.32f, 0.32f, 0));

		}
	}
}
}