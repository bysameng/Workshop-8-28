using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject objectToFollow;

	private Vector3 targetPosition;
	private Vector3 velocity;
	public float smoothTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (objectToFollow != null){
			targetPosition = objectToFollow.transform.position + new Vector3(0, 0, -10f);
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
			                                        ref velocity, smoothTime);
		}
	}
}




