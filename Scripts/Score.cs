using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public int score = 100;
    public int currentLevel =1;
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
        CheckChangeLevel();

    }

    private void CheckChangeLevel()
    {
        if (score > 1000 && currentLevel < 2)
        {
            currentLevel = 2;
            GameController.Instance.nextLevel();
        }

        if (score > 2000 && currentLevel < 3)
        {
            currentLevel = 3;
            GameController.Instance.nextLevel();

        }

        if (score > 3000 && currentLevel < 4)
        {
            currentLevel = 4;
            GameController.Instance.nextLevel();

        }

        if (score > 4000 && currentLevel < 5)
        {
            currentLevel = 5;
            GameController.Instance.nextLevel();

        }

        if (score > 5000 && currentLevel < 6)
        {
            currentLevel = 6;
            GameController.Instance.nextLevel();

        }

        if (score > 6000 && currentLevel < 7)
        {
            currentLevel = 7;
            GameController.Instance.nextLevel();

        }

        if (score > 7000 && currentLevel < 8)
        {
            currentLevel = 8;
            GameController.Instance.nextLevel();

        }

        if (score > 8000 && currentLevel < 9)
        {
            currentLevel = 9;
            GameController.Instance.nextLevel();

        }

        if (score > 9000 && currentLevel < 10)
        {
            currentLevel = 10;
            GameController.Instance.nextLevel();

        }
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
