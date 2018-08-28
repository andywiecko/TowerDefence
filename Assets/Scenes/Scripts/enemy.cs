using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float speed = 5f;
	private Transform target;
	private int path_index = -1;
	public int health = 100;
	public int moneyPrize = 50;

	public GameObject deathEffect;

	void Start()
	{
		next_path();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
		if (health <= 0) Die();
	}

	void Die()
	{
		GameObject effect = (GameObject) Instantiate(deathEffect, transform.position,Quaternion.identity);
		Destroy(effect,5f);
		PlayerStats.Money += moneyPrize; 
		Destroy(gameObject);
	}

	void Update()
	{
		Vector3 direction = target.position - transform.position;
		transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

		if ( Vector3.Distance(target.position,transform.position) <= 0.15f)
		{
			next_path();
		}

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
		Destroy(gameObject);	
	}
}
