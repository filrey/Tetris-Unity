using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        AddToScore(1);

    }

    void AddToScore(int linesCleared)
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

    void ClearScore()
    {
        score = 0;
    }
}
