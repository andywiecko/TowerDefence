using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour {

	public static buildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("more then one buildManager is presented!");
		}	
		instance = this;
		
	}

	public GameObject standardTurretPrefab;
	public GameObject missleLauncherPrefab;
	public GameObject buildEffect;

	private TurretBlueprint turretToBuild;

	public bool CanBuild{ get {return turretToBuild != null;} }
	public bool HasMoney{ get {return PlayerStats.Money >= turretToBuild.cost;} }

	public void BuildTurretOn(Node node)
	{

		if (PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not enough resources!");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;

		GameObject turret = (GameObject) Instantiate(turretToBuild.prefab,node.GetBuildPosition(),Quaternion.identity);
		node.turret = turret;
		
		GameObject effect = (GameObject) Instantiate(buildEffect, node.GetBuildPosition(),Quaternion.identity);
		Destroy(effect,5f);

		Debug.Log ("Turret build! Money left: " + PlayerStats.Money);
	}

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
	}

}
