using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour {


	public static int EnemiesAlive = 0;

	private Wave[] waves;

	public Transform spawnPoint;
	
	public Text countdownText;
	public Text waveNumberText;

	public float countdown = 5f;
	private float start_countdown = 2f;
	private int waveNumber = 0;

	private int TotalWaves = 100;


	private GameObject[] enemyTypes;
	public GameObject enemy_simple;
	public GameObject enemy_tough;
	public GameObject enemy_fast;
	public GameObject enemy_boss;

	void Start()
	{
		
		FillWave();
		EnemiesAlive = 0;

	}

	void FillWave()
	{
		enemyTypes = new GameObject[4];
		enemyTypes[0] = enemy_simple;
		enemyTypes[1] = enemy_tough;
		enemyTypes[2] = enemy_fast;
		enemyTypes[3] = enemy_boss;

		waves = new Wave[TotalWaves];
		for (int i=0; i<TotalWaves; i++)
		{
			Wave waveTemp = new Wave();
			waves[i] = waveTemp; 
			int enemyType = i%4;
			// simply
			if (enemyType == 0)
			{
				waves[i].count = 3*i/4 + 1;
				waves[i].rate = 2;
				waves[i].enemy = enemyTypes[enemyType];
			}
			// tough
			if (enemyType == 1)
			{
				waves[i].count = 2*i/4 + 1;
				waves[i].rate = 3;
				waves[i].enemy = enemyTypes[enemyType];
			}
			// fast
			if (enemyType == 2)
			{
				waves[i].count = 5*i/4 + 1;
				waves[i].rate = 1;
				waves[i].enemy = enemyTypes[enemyType];
			}
			// boss
			if (enemyType == 3)
			{
				waves[i].count = 1;
				waves[i].rate = 1;
				waves[i].enemy = enemyTypes[enemyType];
			}

		}
		
	}

	// Update is called once per frame
	void Update ()
	{
		
		// wait until all enemies are dead
		if (EnemiesAlive > 0) return;

		if (waveNumber >= 1) countdownText.gameObject.SetActive(true);

		if (start_countdown <= 0f)
		{
			//Debug.Log(waveNumber);
			StartCoroutine(Wave());
			start_countdown = countdown;
			countdownText.gameObject.SetActive(false);
			return;
		}

		start_countdown -= Time.deltaTime;
		countdownText.text = "Wave is coming: \n" + Mathf.Round(start_countdown).ToString();
	}
	
	IEnumerator Wave()
	{
		EnemiesAlive = waves[waveNumber].count;
		Debug.Log(EnemiesAlive);
		waveNumberText.text = (waveNumber+1).ToString();
		Wave wave = waves[waveNumber];

		for (int i=0;i<wave.count;i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveNumber++;
		PlayerStats.Rounds++;

		if (waveNumber == waves.Length)
		{
			Debug.Log("Level 1 complete");
		//	this.enabled = false;
		}		
		
	}
	void SpawnEnemy(GameObject _enemy)
	{
		GameObject new_enemy =  (GameObject) Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
		new_enemy.GetComponent<enemy>().startHealth += 10*(Mathf.Pow(waveNumber,1.05f)-1);
		//EnemiesAlive++;

	}
}
