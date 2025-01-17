﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSession : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {

        SetUpSingleton();
        DontDestroyOnLoad(gameObject);
    }

    void SetUpSingleton()
    {
        if (FindObjectsOfType<ScoreSession>().Length > 1)
        {
            Destroy(gameObject);
        }

    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;

    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}