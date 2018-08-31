using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public bool HealthBarSwitch = true;
	public bool TurretHelpSwitch = true;

	public GameObject ShopInfoPanel;
	public GameObject HealthBarInfo;
 
	void Update () 
	{
		if (gameManager.gameEnded) return;
		if (gameManager.gamePaused) return;

		HealthBarToggle();
		TurretHelpToggle();
	}


	void HealthBarToggle()
	{
		if (Input.GetKeyDown("b") )
		{
			HealthBarSwitch = !HealthBarSwitch;
			HealthBarInfo.SetActive(HealthBarSwitch);
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
			foreach (GameObject _enemy in enemies)
			{
				_enemy.GetComponent<enemy>().healthBarInfo.SetActive(HealthBarSwitch);
			}
			//Debug.Log(HealthBarSwitch);
		}
	}

	void TurretHelpToggle()
	{
		if (Input.GetKeyDown("h") )
		{
			TurretHelpSwitch = !TurretHelpSwitch;
			ShopInfoPanel.SetActive(TurretHelpSwitch);
			//Debug.Log(TurretHelpSwitch);
		}
	}


}
