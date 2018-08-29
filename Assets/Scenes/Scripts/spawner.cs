using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour {

	public enemy enemyToSpawn;
	public Transform spawnPoint;
	
	public Text countdownText;
	public Text waveNumberText;

	public float countdown = 5f;
	private float start_countdown = 2f;
	private int waveNumber = 1;

	// Update is called once per frame
	void Update ()
	{
		if (waveNumber == 2) countdownText.gameObject.SetActive(true);

		if (start_countdown <= 0f)
		{
			//Debug.Log(waveNumber);
			StartCoroutine(Wave());
			start_countdown = countdown;
		}

		start_countdown -= Time.deltaTime;
		countdownText.text = Mathf.Round(start_countdown).ToString();
	}
	
	IEnumerator Wave()
	{
		waveNumberText.text = "Wave: " + waveNumber.ToString();
		for (int i=0;i<waveNumber;i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.25f);
		}
		waveNumber++;
		PlayerStats.Rounds++;
		
		
	}
	void SpawnEnemy()
	{
		enemy enemySpawned = (enemy) Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
		enemySpawned.startHealth += 10*(Mathf.Pow(waveNumber,1.05f)-1);

	}
}
