using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
	//Node data
	public bool Filled;
	public Vector2 Location;
	public Vector2 NodeNum;
	public bool isSelected;

	void Start () {
		isSelected = false;
		Filled = false;
	}
}
