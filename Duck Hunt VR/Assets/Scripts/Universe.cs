using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour
{
    private int m_currentScore = 0;
    public int Score { get { return m_currentScore; } set { m_currentScore = value; } }

    private float m_elapsedTime = 0f;
    public float Time { get { return m_elapsedTime; } set { m_elapsedTime = value; } }
    
    private bool hasGun = false;
    public bool HasGun { get { return hasGun; } set { hasGun = value; } }

    private static Universe instance;

    public static Universe Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }

    public void PrintEvent(string text)
    {
        Debug.Log(text);
    }
}
