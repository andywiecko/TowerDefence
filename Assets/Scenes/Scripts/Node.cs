using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color selectColor;
	public Color notEnoughResourcesColor;
	private Renderer rend;
	private Color defaultColor;

	public Vector3 positionOffset;
	
	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	buildManager bm;
	void Start()
	{
		rend = GetComponent<Renderer>();
		defaultColor = rend.material.color;
		bm = buildManager.instance;
	}  

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown()
	{

		if (EventSystem.current.IsPointerOverGameObject()) return;
		
		
		if (turret != null) 
		{
			bm.SelectNode(this);
			return;
		}

		if (!bm.CanBuild) return;

		BuildTurret(bm.GetTurretToBuild());
//		bm.BuildTurretOn(this);
		
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
			{
				Debug.Log("Not enough resources!");
				return;
			}

			PlayerStats.Money -= blueprint.cost;

			GameObject _turret = (GameObject) Instantiate(blueprint.prefab,GetBuildPosition(),Quaternion.identity);
			turret = _turret;
		
			turretBlueprint = blueprint;

			GameObject effect = (GameObject) Instantiate(bm.buildEffect, GetBuildPosition(),Quaternion.identity);
			Destroy(effect,5f);

			Debug.Log ("Turret build! Money left: " + PlayerStats.Money);	
	}

	public void UpgradeTurret()
	{
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
			{
				Debug.Log("Not enough resources!");
				return;
			}

			PlayerStats.Money -= turretBlueprint.upgradeCost;

			Destroy(turret);
			
			//upgrade complete
			GameObject _turret = (GameObject) Instantiate(turretBlueprint.upgradedPrefab,GetBuildPosition(),Quaternion.identity);
			turret = _turret;

			GameObject effect = (GameObject) Instantiate(bm.buildEffect, GetBuildPosition(),Quaternion.identity);
			Destroy(effect,5f);

			isUpgraded = true;

			Debug.Log ("Turret upgraded! Money left: " + PlayerStats.Money);	
	}

	void OnMouseEnter()
	{

		if (EventSystem.current.IsPointerOverGameObject()) return;
		if (!bm.CanBuild) return;

		if (bm.HasMoney) 
		{
			rend.material.color = selectColor;
		}
		else 
		{
			rend.material.color = notEnoughResourcesColor;
		}
	}
	void OnMouseExit()
	{
		rend.material.color = defaultColor;
	}	

}
