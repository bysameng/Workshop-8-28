using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//make sure to assign this guy in the inspector
	//since it defaults to 0
	//play around with it!
	public float maxSpeed;


	void Start () {
		Debug.Log("yay!! i'm in start, or something like that."); //start runs when the script starts existing
	}
	
	void Update () {
		//gameObject.transform.position += new Vector3(1f, 0, 0) * Time.deltaTime;
		float x = Input.GetAxis("Horizontal"); //premade axis by Unity
		float y = Input.GetAxis("Vertical");

		//movement is the amount we will move in this frame
		Vector3 movement = new Vector3(x, y);
		//let's scale our movement (which is between -1 and 1 in x and y) to our maxSpeed
		movement *= maxSpeed;

		//we multiply by Time.deltaTime such that it is framerate independent movement.
		gameObject.transform.position += movement * Time.deltaTime;
	}

	//this is called when a rigidbody enters our IsTrigger collider.
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy"){ //check if it's an enemy... we only want to die if an enemy touches us
			Destroy(this.gameObject); //okay destroy myself
			GameDirector.main.StartMenuTimer(); //tell the gamedirector i'm dead, start that timer
		}
	}

}

