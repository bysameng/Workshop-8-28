using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject objectToFollow;


	//these are used for smoothdamp
	private Vector3 targetPosition;
	private Vector3 velocity;
	public float smoothTime;


	// Update is called once per frame
	void Update () {
		if (objectToFollow != null){ //make sure we dont have null object errors
			targetPosition = objectToFollow.transform.position + new Vector3(0, 0, -10f); //gotta set the camera back a little bit
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition,  //the best function ever
			                                        ref velocity, smoothTime);
		}
	}
}




