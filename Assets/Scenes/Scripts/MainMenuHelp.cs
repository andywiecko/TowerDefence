using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHelp : MonoBehaviour {

	public GameObject HelpPanel;

	public void HelpPanelToggle()
	{
		HelpPanel.SetActive(!HelpPanel.activeSelf);
	}
}
