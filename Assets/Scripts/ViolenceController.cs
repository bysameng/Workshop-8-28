using UnityEngine;
using System.Collections;

public class ViolenceController : MonoBehaviour {

	public GameObject bulletPrefab;

	private float fireDelay = .8f;
	private float fireTimer;
	private bool canFire;

	void Update () {
		if (fireTimer <= 0){
			canFire = true;
		}
		else {
			fireTimer -= Time.deltaTime;
			canFire = false;
		}

		if (Input.GetButton("Fire1") && canFire){
			Shoot();
		}
	}

	private void Shoot(){
		GameObject newBullet = (GameObject)Instantiate(bulletPrefab, 
		                                               transform.position, 
		                                               Quaternion.identity);
		Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = 0; //we want everything to be on the same plane
		newBullet.transform.LookAt(targetPosition); //set bullets rotation to look at that position
		fireTimer = fireDelay; //set our delay
		canFire = false; //cap
	}
}
