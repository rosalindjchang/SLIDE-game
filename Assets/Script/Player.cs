using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject GameManagerGO;
	public GameObject cameraGO;


	private Animator animator;
	public GameObject blob;
	public GameObject bulletposition;
	public GameObject blob2;
	public GameObject bulletpositionleft;

	public Transform playerPos;

	public AudioSource splatsource;

	float speed;
	float originalSpeed;
	float accelerate;


	void Start () {
		
		originalSpeed = 0.06f;
		speed = originalSpeed;
		accelerate = 0.05f;

		animator = GetComponent<Animator> ();


	}

	void OnEnable () {
		//Reset player position in center
		transform.position = playerPos.position;

	}

	void Update () {

		// play'ers current position
		Vector2 position = transform.position;

		//compute the player's new position
		position = new Vector2 (position.x - speed + Time.deltaTime, position.y);

		//update player position
		transform.position = position;

		//This is the bottom left point of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//if player outside screen then destroy
		if (transform.position.x < min.x) {
			GameManagerGO.GetComponent<GameSystem> ().SetGameManagerState (GameSystem.GameManagerState.End);
		}


		if (transform.position.x < min.x) {
			gameObject.SetActive (false);
			var clones = GameObject.FindGameObjectsWithTag ("monstertag"); foreach (var clone in clones){ Destroy(clone); }
		}


		if (Input.GetKeyDown ("left")) {
			animator.SetTrigger ("left");
			GameObject blob201 = (GameObject)Instantiate (blob2);
			blob201.transform.position = bulletpositionleft.transform.position; 
			StartCoroutine (speedPickup ());
			splatsource.Play ();
		} 


		if (Input.GetKeyDown ("right")) {
			animator.SetTrigger ("right");
			GameObject blob01 = (GameObject)Instantiate (blob);
			blob01.transform.position = bulletposition.transform.position; 
			splatsource.Play ();

		}


		if (originalSpeed > 0.05f) {
			speed += accelerate * Time.deltaTime;
		}
			

	}


	IEnumerator speedPickup () {
		speed -= 0.15f;
		yield return new WaitForSeconds (0.1f);
		revertSpeed ();
	} 

	void revertSpeed() {
		speed = originalSpeed;

	}


	void OnTriggerEnter2D(Collider2D col) {
		//Detect collision of player with enemy  
		if ((col.tag == "monstertag")) {

			GameManagerGO.GetComponent<GameSystem> ().SetGameManagerState (GameSystem.GameManagerState.End);
			var clones = GameObject.FindGameObjectsWithTag ("monstertag"); foreach (var clone in clones){ Destroy(clone); }
			gameObject.SetActive (false);


		}
	}
}
