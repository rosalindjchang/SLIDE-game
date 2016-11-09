using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour {

	Text scoreText;

	int score;

	public int Score
	{
		get {
			return this.score;
		} set {
			this.score = value;
			UpdateScoreText();
		}
	}

	void Start () {
		scoreText = GetComponent<Text> ();

	}


	void UpdateScoreText () {
		string scoreStr = string.Format ("{0:000}", score);
		scoreText.text = scoreStr;
	}

}
