using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float maxSpeed = 2f;

	private bool alive = true;
	private float dyingSmoothTime = .5f;
	private Vector3 dyingVelocity;

	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		if (!alive){
			transform.localScale = Vector3.SmoothDamp(transform.localScale,
			                                          Vector3.zero,
			                                          ref dyingVelocity,
			                                          dyingSmoothTime);
		}
		if (player != null){
			transform.position = Vector3.MoveTowards(transform.position,
			                                         player.transform.position,
			                                         maxSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Bullet"){
			EnemyFactory.main.SpawnEnemy();
			EnemyFactory.main.SpawnEnemy();
			EnemyFactory.main.SpawnEnemy();
			Destroy(other.gameObject);
			alive = false;
			gameObject.collider.enabled = false;
			Destroy(this.gameObject, dyingSmoothTime + 2f);
		}
	}

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
