using UnityEngine;
using System.Collections;

public class cloud2script : MonoBehaviour {

	public float speed = 2;

	public Vector3 startPos;

	void Start () {
		startPos = transform.position;
	}

	void Update () {


		if (transform.position.x < -13) {
			transform.position = new Vector3 (12.47f, -3f);
			transform.Translate (Vector3.left * Time.deltaTime * speed);
			if (Time.time > 30f) {
				transform.position = new Vector3 (12.47f, -6f);
				transform.Translate (Vector3.left * Time.deltaTime * speed);
			}
		} else {
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}


	}
}
