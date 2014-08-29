using UnityEngine;
using System.Collections;

//controls all the violence in the game
public class ViolenceController : MonoBehaviour {

	//make sure to assign this guy in the inspector
	public GameObject bulletPrefab;

	//these are used to cap the firerate
	private float fireDelay = .2f; //play with this!
	private float fireTimer;
	private bool canFire;


	void Update () {
		//firerate capping
		//only when the timer is less than 0 we say we can shoot
		if (fireTimer <= 0){
			canFire = true;
		}
		else { //if it's not less than 0, then we will count down the timer
			fireTimer -= Time.deltaTime;
			canFire = false; //cant fire when it's counting down
		}

		//will only fire if the button is down and we can fire
		if (Input.GetButton("Fire1") && canFire){
			Shoot();
		}
	}

	//this method spawns a bullet to where the mouse is pointing
	private void Shoot(){
		//make our bullet
		GameObject newBullet = (GameObject)Instantiate(bulletPrefab, 
		                                               transform.position, 
		                                               Quaternion.identity);
		//get our position to where we want to shoot the bullet to
		//note: only works for orthogonal cameras here, youd have to change the last parameter if you want perspective cam
		Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = 0; //we want everything to be on the same plane
		newBullet.transform.LookAt(targetPosition); //set bullets rotation to look at that position
		fireTimer = fireDelay; //set our delay
		canFire = false; //cap
	}
}
