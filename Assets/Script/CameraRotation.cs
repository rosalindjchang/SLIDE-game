using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {


	private Vector3 startPos;
	private Vector3 targetPos;

	private  Quaternion startRot = Quaternion.Euler(0,0,0);
	private Quaternion targetRot = Quaternion.Euler (0, 0, 0);
	private float speedRot = 0.02f;
	private float speedPos = 0.018f;

	public Quaternion originalRotation; 
	public Transform cameraPos;

	public float startTime;
	public float elapsedTime;


	void Start () {
		originalRotation = transform.rotation; // save the initial rotation
		startRot = this.transform.rotation;
		targetRot = Quaternion.Euler (0, 0, -24f);
		startPos = transform.position;
		targetPos  = new Vector3 (-0.97f, -3.29f,-10);
		startTime = Time.time;
	}

	void Update () {
		elapsedTime = Time.time - startTime;
		transform.rotation = Quaternion.Slerp (startRot, targetRot, elapsedTime  * speedRot);
		transform.position = Vector3.Lerp (startPos, targetPos, elapsedTime  * speedPos); 
	}
		


	/*public void CameraReturn () {
		//transform.rotation=Quaternion.Slerp (transform.rotation, startRot, speedRot*Time.deltaTime);
		transform.position = startPos;
		transform.rotation = startRot;

	}*/

}
