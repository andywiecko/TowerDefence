using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerMenu : MonoBehaviour {

	public enemy enemyToSpawn;
	public Transform spawnPoint;
	
	public float countdown = 5f;
	private float start_countdown = 2f;
	private int waveNumber = 3;


	void Update ()
	{
		
		if (start_countdown <= 0f)
		{
			//Debug.Log(waveNumber);
			StartCoroutine(Wave());
			start_countdown = countdown;
		}

		start_countdown -= Time.deltaTime;
		
	}
	
	IEnumerator Wave()
	{
		
		for (int i=0;i<waveNumber;i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
		
	}
	void SpawnEnemy()
	{
		enemy enemySpawned = (enemy) Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
		enemySpawned.healthBarInfo.SetActive(false);
	}
}
