using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using KartGame.Track;

public class MainMenu : MonoBehaviour
{
	public TextMeshProUGUI bestTimeText;

    // Start is called before the first frame update
    void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (!bestTimeText) {
        	Debug.LogWarning("Please, assign a TextMeshPro Object to display Player Best Time");
        	return;
        }
		bestTimeText.gameObject.SetActive(true);

        if (bestTime <= 0.0f) {
    		bestTimeText.text = "Play and beat your best time!";
    		return;
        }

		if (bestTime < 5.0f) {
			bestTimeText.text = "Hey, are you cheating the game?";
			return;
		}

		bestTimeText.text = "Best  Time: " + bestTime.ToString("0.00") + "s";
    }


    public void StartRace() 
    {
    	SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame() 
    {
    	Application.Quit();
    }

}
