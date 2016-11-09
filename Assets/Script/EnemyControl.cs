using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {


	float speed;
	float originalspeed;


	void Start () {
		originalspeed = 0.07f;
		speed = originalspeed;

	}
	
	void Update () {
		
		// get the monster's current position
		Vector2 position = transform.position;

		//compute the monster's new position
		position = new Vector2 (position.x - speed + Time.deltaTime ,position.y);

		//update enemy position
		transform.position = position;

		//This is the bottom left point of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//if EnemyControl when outside screen then destroy
		if (transform.position.x < min.x) {
			Destroy (gameObject);
		}

		if (originalspeed >= 0.07f) {
			speed += Time.deltaTime / 40;
		}

	}


	void OnTriggerEnter2D(Collider2D col) {
		if ((col.tag == "playertag")||(col.tag == "blobtag")) {
			Destroy (gameObject);
			AudioSource roar = GetComponent<AudioSource>();
			roar.Play ();
		}
			

	}
}
