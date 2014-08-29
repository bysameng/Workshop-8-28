using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 15f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * 10f * Time.deltaTime;
	}
}
