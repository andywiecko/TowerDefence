using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour {

	public static Transform[] point_paths;

	void Awake()
	{
		point_paths = new Transform[transform.childCount];
	
		for (int i=0;i<point_paths.Length;i++)
		{
			point_paths[i] = transform.GetChild(i);
		}
	}

}
