using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

	public CoinCounter coinCounter;


	bool active = true;

    // Start is called before the first frame update
    void Start()
    {
    	if (!coinCounter) {
    		active = false;
    		Debug.LogWarning("Coin without coin counter assigned");
    	}
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * 90f);
    }

    void OnTriggerEnter(Collider other)
    {
    	//Debug.Log(other);
    	if (active && other.gameObject.tag == "Player") {
    		active = false;
    		coinCounter.AddCoin();
    		StartCoroutine("Respawn");
    		transform.Find("Cylinder").gameObject.SetActive(false);
    	}
    }


	IEnumerator Respawn() 
	{
		yield return new WaitForSeconds(10f);
		transform.Find("Cylinder").gameObject.SetActive(true);
		active = true;
	}
}
