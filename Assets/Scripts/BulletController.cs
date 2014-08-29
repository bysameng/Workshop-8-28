using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 15f); //destroy this bullet after 15 seconds
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * 10f * Time.deltaTime; //move it in the local z-axis of this bullet at 10units/sec
	}
}
