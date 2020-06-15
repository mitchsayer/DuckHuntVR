using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates {
    MainMenu = 0,
    Play,
    Result
}

public class Universe : MonoBehaviour
{
    private int m_currentScore = 0;
    public int Score { get { return m_currentScore; } set { m_currentScore = value; } }
     
    private float m_elapsedTime = 0f;
    public float Time { get { return m_elapsedTime; } set { m_elapsedTime = value; } }
    
    private bool hasGun = false;
    public bool HasGun { get { return hasGun; } set { hasGun = value; } }

    private int gameState = (int)GameStates.MainMenu;
    public int GameState { get; set; }

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
