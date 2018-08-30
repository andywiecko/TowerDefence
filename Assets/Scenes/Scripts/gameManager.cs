using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public static bool gameEnded;
	public static bool gamePaused;

	public GameObject gameOverUI;
	
	
	void Start()
	{
		gameEnded = false;
		gamePaused = false;
	}

	void Update ()
	{
		if (gameEnded) return;

		if (Input.GetKeyDown("e"))
		{
			EndGame();
		}

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}	

	}

	void EndGame()
	{	
		gameEnded = true;
		Debug.Log("Game over");
		gameOverUI.SetActive(true);
	}
}
