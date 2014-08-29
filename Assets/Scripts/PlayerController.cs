using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;

	void Start () {
		Debug.Log("yay!! i'm in start, or something like that.");
	}
	
	void Update () {
		//gameObject.transform.position += new Vector3(1f, 0, 0) * Time.deltaTime;
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(x, y);
		movement *= maxSpeed;

		gameObject.transform.position += movement * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy"){
			Destroy(this.gameObject);
			GameDirector.main.StartMenuTimer();
		}
	}

}

