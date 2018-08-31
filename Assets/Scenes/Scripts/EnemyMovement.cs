using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enemy))]
public class EnemyMovement : MonoBehaviour {


	private Transform target; 
	private int path_index = -1;
	private enemy enemyInst;

	void Start()
	{
		enemyInst = GetComponent<enemy>();
		next_path();
	}
	

	void Update()
	{
		Vector3 direction = target.position - transform.position;
		transform.Translate(direction.normalized * enemyInst.speed * Time.deltaTime, Space.World);

		if ( Vector3.Distance(target.position,transform.position) <= 0.15f)
		{
			next_path();
		}
	
		enemyInst.speed = enemyInst.startSpeed;  
	}

	void next_path()
	{
		if (path_index >= path.point_paths.Length-1)
		{
			EndPath();
			return;
		}
		path_index++;
		target = path.point_paths[path_index];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		spawner.EnemiesAlive--;
		Destroy(gameObject);	
	}


}
