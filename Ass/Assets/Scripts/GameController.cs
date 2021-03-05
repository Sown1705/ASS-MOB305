using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text scoreText, gameOverScoreText;
    public GameObject gameOverText;
    public bool isGameOver = false;

	public GameObject particle;
	private int score=0;
	
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance == this)
		{
			Destroy(gameObject);
		}
	}

	public void AddScore(int score)
	{
		this.score += score;
		scoreText.text = "Score : " + this.score;
		GameObject g1 = Instantiate(particle);
		Destroy(g1, 2);
	}

	public void GameOver()
	{
		gameOverScoreText.text = "Your Score: " + this.score;
		gameOverText.SetActive(true);

		isGameOver = true;
	}
}
