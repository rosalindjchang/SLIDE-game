using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour {

	public GameObject MonsterGo;
	public Transform spawnPos;



	float maxSpawnRateInSeconds = 5f;

	void Start () {
		Invoke ("SpawnMonster", maxSpawnRateInSeconds);

		//Increase spawn rate every 30 sec
		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);

	}
	


	void SpawnMonster () {
		

		GameObject aMonster = (GameObject)Instantiate (MonsterGo);

		aMonster.transform.position = spawnPos.position;

		NextMonsterSpawn ();
	}

	void NextMonsterSpawn() {
		float spawnInSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			spawnInSeconds = Random.Range (maxSpawnRateInSeconds-1, maxSpawnRateInSeconds);
			Invoke ("SpawnMonster", spawnInSeconds);
		} else {
			spawnInSeconds = 1f;
			Invoke ("SpawnMonster", spawnInSeconds);
		}
	}

	void IncreaseSpawnRate () {
		if (maxSpawnRateInSeconds > 1f) 
			maxSpawnRateInSeconds--;
		if(maxSpawnRateInSeconds ==1f)
			CancelInvoke("IncreaseSpawnRate");
	} 

	public void StartEnemySpawner(){
		Invoke ("SpawnMonster", maxSpawnRateInSeconds);

		InvokeRepeating ("IncreaseSpawnRate", 0f, 6f);
	}

	public void StopEnemySpawner() {
		CancelInvoke ("SpawnMonster");
		CancelInvoke ("IncreaseSpawnRate");
	}


}
