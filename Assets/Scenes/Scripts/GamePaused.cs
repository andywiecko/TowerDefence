using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GamePaused : MonoBehaviour {

	public string menu = "MainMenu";
	public GameObject ui;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	} 


	public void Toggle()
	{
		if (gameManager.gameEnded) return;

		ui.SetActive(!ui.activeSelf);
		
		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}	
	}


	public void Reset()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(menu);
	}

}
