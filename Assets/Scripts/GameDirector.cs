using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {
	public static GameDirector main;

	public GameObject player;

	private float restartTimer = 2f;
	private float restartCount;

	// Use this for initialization
	void Start () {
		main = this;
	}

	void Update(){
		if (restartCount > 0){
			restartCount -= Time.deltaTime;
			if (restartCount <= 0){
				LoadMenu();
			}
		}
	}

	public void StartMenuTimer(){
		restartCount = restartTimer;
	}

	public void LoadMenu(){
		Application.LoadLevel("menu");
	}
	
}
