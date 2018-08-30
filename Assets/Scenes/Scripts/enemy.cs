using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour {

	public float startSpeed = 5f;

	[HideInInspector]
	public float speed;
	//private Transform target;
	//private int path_index = -1;
	public float startHealth = 100;
	private float health;
	public int moneyPrize = 50;


	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;
	public GameObject healthBarInfo;

	void Start()
	{
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0) Die();
		healthBar.fillAmount = health/startHealth;
	}

	public void Slow(float amount)
	{
		speed = startSpeed * (1-amount);
	}

	void Die()
	{
		GameObject effect = (GameObject) Instantiate(deathEffect, transform.position,Quaternion.identity);
		Destroy(effect,5f);
		PlayerStats.Money += moneyPrize; 
		Destroy(gameObject);
	}


}
