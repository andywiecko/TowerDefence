using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {


	public TurretBlueprint standardTurret;
	public TurretBlueprint missleLauncher;
	public TurretBlueprint laserBeamer;
	buildManager bm;

	void Start()
	{
		bm = buildManager.instance;
	}
	
	public void SelectStandardTurret()
	{
		Debug.Log("Standard Turret selected!");
		bm.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissleLauncher()
	{
		Debug.Log("Missle Launcher selected!");
		bm.SelectTurretToBuild(missleLauncher);
	} 
	public void SelectLaserBeamer()
	{
		Debug.Log("Laser Beamer selected!");
		bm.SelectTurretToBuild(laserBeamer);
	} 

}
