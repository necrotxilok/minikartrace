using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
	public GameObject bestLapTimeTextObject;

    // Start is called before the first frame update
    void Start()
    {
        float bestLapTime = PlayerPrefs.GetFloat("BestLapTime");

        if (!bestLapTimeTextObject) {
        	Debug.Log("Please, assign a TextMeshPro Object to display Player Lap Time");
        	return;
        }
        TextMeshPro bestLapTimeText = bestLapTimeTextObject.GetComponent<TextMeshPro>();

        if (bestLapTime == 0.0f) {
    		bestLapTimeTextObject.SetActive(false);
    		return;
        }

		bestLapTimeTextObject.SetActive(true);
		if (bestLapTime < 5.0f) {
			bestLapTimeText.text = "Hey, are you cheating the game?";
			return;
		}

		bestLapTimeText.text = "Best Lap Time: " + bestLapTime + "s";
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
