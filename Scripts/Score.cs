﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public int score = 100;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        GameController.Instance.PlayerScoreScriptToGC(this);
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToScore(int linesCleared)
    {
        int points=0;

        switch (linesCleared)
        {
            case 1:
                points = 100;
                break;
            case 2:
                points = 300;
                break;
            case 3:
                points = 500;
                break;
            case 4:
                points = 800;
                break;
            case 5:
                points = 1200;
                break;
            default:
                break;
        }
        score += points;
        scoreText.text = score.ToString();

    }

    void SingleLineClear()
    {
        AddToScore(1);
    }

    void DoubleLineClear()
    {
        AddToScore(2);
    }

    void TripleLineClear()
    {
        AddToScore(3);
    }

    void QuadLineClear()
    {
        AddToScore(4);
    }

    void ConsequtiveTetris()
    {
        AddToScore(5);
    }
    void ClearScore()
    {
        score = 0;
    }
}
