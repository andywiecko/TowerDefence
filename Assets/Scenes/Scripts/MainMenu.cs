﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainScene";

	public void Play()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void Quit()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}

	public void Help()
	{
		Debug.Log("Help!");
	}

}
