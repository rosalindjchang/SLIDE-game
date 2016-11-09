using UnityEngine;
using System.Collections;

public class playerStart : MonoBehaviour {


	public Transform target;
	public Transform target2;
	public float speed;

	void Update() {

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);

		if (transform.position.x < -5.6f) {
			speed *= -1;
			transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
		} if (transform.position.x > 3.2f) {
			speed *= -1;
		}
	}

}
