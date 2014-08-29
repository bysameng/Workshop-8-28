using UnityEngine;
using System.Collections;

//this class is the "mastermind" brain of the operations within our game scene
public class GameDirector : MonoBehaviour {
	public static GameDirector main; //our singleton static reference

	//this is for convenience. we haven't actually used this BUT
	//you could replace all GameObject.FindObjectsWithTag("Player") with just
	//GameDirector.main.player
	//and have almost zero performance impact that way, since you're not using Find.
	public GameObject player;

	//this is just some timer stuff for when we're restarting
	private float restartTimer = 2f;
	//we assign restartCount only when we call StartMenuTimer();
	private float restartCount;

	// Use this for initialization
	void Start () {
		main = this; //make our "singleton"
	}

	void Update(){
		//if restartCount is over 0, that means we set it to something, since 0 is default.
		if (restartCount > 0){
			restartCount -= Time.deltaTime; //let's decrement our timer by time passed this frame
			if (restartCount <= 0){ //okay, after we decrement it let's check if it's under 0 now
				LoadMenu(); //if it IS under zero let's stop this scene and load the menu again.
			}
		}
	}

	//this function will set our restartCount to the restartTimer value
	//therefore putting our update loop into action
	public void StartMenuTimer(){
		restartCount = restartTimer;
	}

	//load menu literally just loads the menu. that's it
	public void LoadMenu(){
		Application.LoadLevel("menu"); //keep in mind the scene name might be different in yours.
		//the scene name is the file name.
		//make sure it's assigned inside of build settings.
	}
	
}
