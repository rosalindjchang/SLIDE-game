using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {

	public GameObject cameraGO;
	public GameObject cameraStill;
	public GameObject Play;
	public GameObject Startpage;
	public GameObject Endpage;
	public GameObject monsterSpawner;
	public GameObject monsterSpawner2;
	public GameObject scoreUITextGo; 
	public Transform scoretext;

	public GameObject player;
	public float WaitTime=60f;

	public enum GameManagerState
	{
		Start,
		Play,
		End,
	}

	GameManagerState GMState;

	void Start () {
		
		GetComponent<GameSystem> ().SetGameManagerState (GameSystem.GameManagerState.Start);

		//GMState = GameManagerState.Start;
	}

	void Update () {

	
		if(Input.GetKeyDown("space"))
		{
			GetComponent<GameSystem> ().SetGameManagerState (GameSystem.GameManagerState.Play);

		} 

		if (GMState == GameManagerState.Play) {
			cameraGO.SetActive (true);
			cameraStill.SetActive (false);

		} else {
			cameraGO.SetActive (false);
			cameraStill.SetActive (true);
		}
			
	}

	IEnumerator Wait (float Count){
		print(Time.time);
		yield return new WaitForSeconds(34f); //time in seconds to wait.
		monsterSpawner2.GetComponent<MonsterSpawn2> ().StartEnemySpawner ();

	}

	void UpdateGameManagerState(){
		switch (GMState) {
		case GameManagerState.Start:

			Play.SetActive (false);
			Endpage.SetActive (false);
			Startpage.SetActive (true);
			monsterSpawner.GetComponent<MonsterSpawn> ().StopEnemySpawner ();
			monsterSpawner2.GetComponent<MonsterSpawn2> ().StopEnemySpawner ();

			break;

		case GameManagerState.Play:
			
			// Reset score
			scoreUITextGo.GetComponent<GameScore> ().Score = 0;
			Play.SetActive (true);
			player.SetActive (true);
			Endpage.SetActive (false);
			Startpage.SetActive (false);
			monsterSpawner.GetComponent<MonsterSpawn> ().StartEnemySpawner ();
			StartCoroutine (Wait (34));

			break;

		case GameManagerState.End:
			SceneManager.LoadScene("gameover");
			SceneManager.UnloadScene ("play");

			break;

		}
	}

	public void SetGameManagerState(GameManagerState state) {
		GMState = state;
		UpdateGameManagerState ();
	}


}
