using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{

	public TextMeshProUGUI coinsText;
	
	int coins = 0;
	AudioSource coinSound;

	void Start()
	{
        coinSound = GetComponent<AudioSource>();

        if (!coinsText) {
        	Debug.LogWarning("Please, assign UI Counter Text");
        }
	}

	public void AddCoin() 
	{
		coinSound.Play();
		coins++;
		coinsText.text = "COINS: " + coins.ToString("0");
	}

	public int GetCoins()
	{
		return coins;
	}

}
