using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class NodeUI : MonoBehaviour {

	public GameObject ui;
	public Text upgradeCost;
	public Button upgradeButton;
	private Node target;

	public Text sellAmount;

	public void SetTarget(Node _target)
	{
		target = _target;
		transform.position = target.GetBuildPosition();

		if (!target.isUpgraded)
		{
			upgradeCost.text = "UPGRADE\n$" + target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		}
		else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}

		sellAmount.text = "SELL\n$" + target.turretBlueprint.GetSellAmount();

		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}

	public void Upgrade()
	{
		Debug.Log("upgrade!");
		target.UpgradeTurret();
		buildManager.instance.DeselectNode();
	}

	public void Sell()
	{
		target.SellTurret();
		buildManager.instance.DeselectNode();
	}
}
