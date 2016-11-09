using UnityEngine;
using System.Collections;

public class Bulletleft : MonoBehaviour {

	float speed;

	void Start () {

		speed = 8f;
	}

	void Update () {
		Vector2 position = transform.position;

		position = new Vector2 (position.x  - speed * Time.deltaTime, position.y);

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		if (transform.position.x > max.x) {
			Destroy (gameObject);
		}

	}
}
