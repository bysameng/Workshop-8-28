using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	public static EnemyFactory main;

	//be sure this is assigned in the inspector!
	public GameObject enemyPrefab;
	private GameObject player;

	void Start(){
		main = this; //set our static reference to make our "singleton"
		player = GameObject.FindGameObjectWithTag("Player"); //find the player that we'll be basing our spawns off of
	}

	//spawnenemy creates an enemy somewhere in the scene
	//not that close to the player

	public void SpawnEnemy(){
		Vector3 spawnPosition = Vector3.zero; //spawnPostion will be copied values 0,0,0
		spawnPosition.x = Random.Range(10f, 20f); //set random values
		spawnPosition.y = Random.Range(10f, 20f);

		//have a 50% chance to have a negative value for both x and y
		if (Random.value > .5f){
			spawnPosition.x = -spawnPosition.x;
		}
		if (Random.value > .5f){
			spawnPosition.y = -spawnPosition.y;
		}

		//okay, make a newEnemy and then make its scale random
		GameObject newEnemy = (GameObject)Instantiate(enemyPrefab,
		            player.transform.position + spawnPosition,
		            Quaternion.identity);
		//make a random size
		float size = Random.Range(.5f, 3f);
		//assign the size
		newEnemy.transform.localScale = new Vector3(size, size, size);
	}
}
