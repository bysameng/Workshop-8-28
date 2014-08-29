using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	public static EnemyFactory main;

	public GameObject enemyPrefab;
	private GameObject player;

	void Start(){
		main = this;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	//spawnenemy creates an enemy somewhere in the scene
	//not that close to the player

	public void SpawnEnemy(){
		Vector3 spawnPosition = Vector3.zero; //spawnPostion will be copied values 0,0,0
		spawnPosition.x = Random.Range(10f, 20f);
		spawnPosition.y = Random.Range(10f, 20f);
		if (Random.value > .5f){
			spawnPosition.x = -spawnPosition.x;
		}
		if (Random.value > .5f){
			spawnPosition.y = -spawnPosition.y;
		}
		GameObject newEnemy = (GameObject)Instantiate(enemyPrefab,
		            player.transform.position + spawnPosition,
		            Quaternion.identity);
		float size = Random.Range(.5f, 3f);
		newEnemy.transform.localScale = new Vector3(size, size, size);
	}
}
