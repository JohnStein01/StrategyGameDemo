using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Scroll : MonoBehaviour {

	public Button BarracksButton;
	public Button PowerplantButton;
	public RectTransform Content;

	List<Button> ButtonsB = new List<Button>();
	List<Button> ButtonsP = new List<Button>();

	// Create a list of building buttons 
	void Awake(){
		
		BarracksButton = BarracksButton.GetComponent<Button>();
		PowerplantButton = PowerplantButton.GetComponent<Button>();	

		for (int i = 0; i < 13; i++) {
			
			ButtonsB.Add(Instantiate (BarracksButton) as Button);
			ButtonsB [i].transform.parent = Content.transform;
			ButtonsB[i].GetComponent<RectTransform>().anchoredPosition=new Vector2(-0.29f,2.45f-i*0.5f);

			ButtonsP.Add(Instantiate (PowerplantButton) as Button);
			ButtonsP[i].transform.parent = Content.transform;
			ButtonsP[i].GetComponent<RectTransform>().anchoredPosition=new Vector2(0.29f,2.45f-i*0.5f);

		}

	}
	
	// Change the location of the created button objects, when there is a scroll
	void Update () {	

		for (int i = 0; i < ButtonsB.Count; i++) {
			
			if (ButtonsB [i].GetComponent<RectTransform> ().anchoredPosition.y + Content.anchoredPosition.y > 2f) {
				ButtonsB [i].GetComponent<RectTransform> ().anchoredPosition = ButtonsB [i].GetComponent<RectTransform> ().anchoredPosition - new Vector2(0,4.5f);
				ButtonsP [i].GetComponent<RectTransform> ().anchoredPosition = ButtonsP [i].GetComponent<RectTransform> ().anchoredPosition - new Vector2(0,4.5f);
			}
		}

		for (int i = 0; i < ButtonsB.Count; i++) {

			if (ButtonsB [i].GetComponent<RectTransform> ().anchoredPosition.y + Content.anchoredPosition.y < -2f) {
				ButtonsB [i].GetComponent<RectTransform> ().anchoredPosition = ButtonsB [i].GetComponent<RectTransform> ().anchoredPosition + new Vector2(0,4.5f);
				ButtonsP [i].GetComponent<RectTransform> ().anchoredPosition = ButtonsP [i].GetComponent<RectTransform> ().anchoredPosition + new Vector2(0,4.5f);
			}
		}
}

}


