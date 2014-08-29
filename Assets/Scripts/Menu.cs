using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){ //if space is pressed, then load game scene
			Application.LoadLevel("Scene1"); //load the scene in the Scenes folder with the name "Scene1"
		}
	}

}
