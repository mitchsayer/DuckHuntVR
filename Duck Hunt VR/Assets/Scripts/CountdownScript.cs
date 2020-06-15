using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = false;
    private bool doOnce = false;

    public UnityEvent onTimeUp;

    void Start()
    {
        timer = mainTimer;
	}

    void Update()
    {
        if (canCount)
        {
            if (timer >= 0f)
            {
                timer -= Time.deltaTime;
                Universe.Instance.Time = timer;
                uiText.text = timer.ToString("0");
            }
            else if (timer <= 0f && !doOnce)
            {
                canCount = false;
                doOnce = true;
                Universe.Instance.GameState = 3;
                Universe.Instance.Time = timer;
                uiText.text = "0";
                timer = 0f;
                onTimeUp?.Invoke();
            }
        }
        else
        {
            if (Universe.Instance.HasGun)
            {
                timer = mainTimer;
            }
            if (Universe.Instance.GameState == 1)
                canCount = true;
        }
    
    }
}
