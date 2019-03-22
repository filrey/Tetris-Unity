using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LinesCleared : MonoBehaviour
{
    public int lines = 0;
    public Text linesText;

    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        GameController.Instance.LinesClearedScriptToGC(this);

        linesText.text = lines.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToLines(int linesCleared)
    {
        int points = 0;

        switch (linesCleared)
        {
            case 1:
                points = 1;
                break;
            case 2:
                points = 2;
                break;
            case 3:
                points = 3;
                break;
            case 4:
                points = 4;
                break;
            default:
                break;
        }
        lines += points;
        linesText.text = lines.ToString();

    }

    void SingleLineClear()
    {
        AddToLines(1);
    }

    void DoubleLineClear()
    {
        AddToLines(2);
    }

    void TripleLineClear()
    {
        AddToLines(3);
    }

    void QuadLineClear()
    {
        AddToLines(4);
    }

    void Clearlines()
    {
        lines = 0;
    }
}
