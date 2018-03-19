using UnityEngine;

public class Resize:MonoBehaviour
{
	public float width=Screen.width;
	public float height=Screen.height;

	void Awake(){
		Camera.main.aspect = height / width;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

}