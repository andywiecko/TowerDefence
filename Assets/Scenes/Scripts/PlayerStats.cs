using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {


	public Text MoneyText;
	public static int Money;
	public int startMoney = 400;

	public Text LivesText;
	public static int Lives;
	public int startLives = 10;

	void Start()
	{
		Money = startMoney;
		Lives = startLives;
		
		MoneyText.text = "Money: " + Money.ToString();
		LivesText.text = "Lives: " + Lives.ToString();
	}
	void Update()
	{
		MoneyText.text = "Money: " + Money.ToString();
		LivesText.text = "Lives: " + Lives.ToString();
	}


	

}
