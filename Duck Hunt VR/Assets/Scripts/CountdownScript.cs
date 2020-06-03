using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    void Start()
    {
        timer = mainTimer;
	}

    void Update()
    {
        if (timer >= 0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("0");
		}

        else if (timer <= 0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0";
            timer = 0f;
		}
    }
}
