using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//the maximum speed at which this enemy will follow the player
	public float maxSpeed = 2f;

	//when alive is false, we will animate the sphere to be smaller
	private bool alive = true;

	//used for the smoothdamp functions
	private float dyingSmoothTime = .5f;
	private Vector3 dyingVelocity;

	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		if (!alive){ //it's dead! let's do our animation scaling it downwards
			transform.localScale = Vector3.SmoothDamp(transform.localScale,
			                                          Vector3.zero,
			                                          ref dyingVelocity,
			                                          dyingSmoothTime);
		}
		if (player != null){ //make sure the player isn't destroyed!
			transform.position = Vector3.MoveTowards(transform.position,
			                                         player.transform.position,
			                                         maxSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other){
		//make sure it is a bullet that enters our trigger
		if (other.tag == "Bullet"){ //okay, it is. let's make more enemies!
			EnemyFactory.main.SpawnEnemy();
			EnemyFactory.main.SpawnEnemy();
			EnemyFactory.main.SpawnEnemy();
			Destroy(other.gameObject); //let's destroy the bullet that collided with us
			alive = false; //let's set our guy to dead, so we can animate its death in Update
			gameObject.collider.enabled = false; //turn off the collider so we can't kill player after shot
			Destroy(this.gameObject, dyingSmoothTime + 2f); //kill myself once the animation is most likely done
		}
	}

	//this guy is using a coroutine method
	// OnTriggerEnter is called when a rigidbody enters this gameObject's trigger collider
//	IEnumerator OnTriggerEnter(Collider other){
//		//destroy the enemy here.
//		Destroy(other.gameObject);
//		for(float t = 0; t < 1f; t += Time.deltaTime){
//			float scale = Mathf.SmoothStep(5, 0, t/1);
//			transform.localScale = new Vector3(scale, scale, scale);
//			yield return new WaitForEndOfFrame();
//		}
//		Destroy(this.gameObject);
//	}
}
