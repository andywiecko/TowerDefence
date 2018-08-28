using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text roundText;

	void OnEnable()
	{
		roundText.text = PlayerStats.Rounds.ToString();
	}	

	public void Reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	
	public void Menu()
	{
		Debug.Log("goto menu");
	}

}
