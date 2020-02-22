using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButton : MonoBehaviour
{

	public float startScale = 1.0f;
	public float endScale = 2.0f; 
	public float duration = 1.0f;

	public UnityEvent onAnimationEnd;

	private bool animate;
    private float startTime;


    // Update is called once per frame
    void Update()
    {
        if (animate) {
			float timeCovered = (Time.time - startTime) / duration;
			var nextSize  = Vector3.Lerp(Vector3.one * startScale, Vector3.one * endScale, timeCovered);

			transform.localScale = nextSize;

			if (Vector3.Distance(transform.localScale, Vector3.one * endScale) < 0.05) {
				onAnimationEnd.Invoke();
				StopAnimation();
			}
        }
    }

    public void StartAnimation()
    {
    	startTime = Time.time;
    	animate = true;
    }

    public void StopAnimation()
    {
    	animate = false;
    }
}
