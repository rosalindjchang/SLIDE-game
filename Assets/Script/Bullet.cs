using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	GameObject scoreUITextGo;

	float speed;
	public GameObject ExplosionBlob;


	void Start () {

		speed = 8f;
		scoreUITextGo = GameObject.FindGameObjectWithTag ("scoretag");

	}
	
	void Update () {
		Vector2 position = transform.position;

		position = new Vector2 (position.x  + speed * Time.deltaTime, position.y);

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		if (transform.position.x > max.x) {
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "monstertag") {
			Destroy (gameObject);
			PlayExplosion ();
			scoreUITextGo.GetComponent<GameScore> ().Score += 10;

		}
	}


	void PlayExplosion() {
		GameObject explosion = (GameObject)Instantiate(ExplosionBlob);
		explosion.transform.position = transform.position;

	}
}
