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
	
	[Header("Optional")]
	public GameObject turret;


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
		if (!bm.CanBuild) return;
		if (turret != null) 
		{
			Debug.Log("Field is occupied!");
			return;
		}

		bm.BuildTurretOn(this);
		
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
