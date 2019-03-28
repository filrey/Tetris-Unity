using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<MonoBehaviour> eventSubscribedScripts = new List<MonoBehaviour>();
    public MonoBehaviour playerScore;
    public MonoBehaviour linesCleared;
    public MonoBehaviour gameUI;
    //public MonoBehaviour speed;
    public MonoBehaviour level;
    public MonoBehaviour gameLogic;
    public MonoBehaviour soundEffects;






    public int gameEventID = 0;
    //public int linesCleared = 0;
    //public int level = 0;
    public float gameSpeed = 1.0f;

    private static GameController instance;

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameController>();
            }

            if(FindObjectsOfType<GameController>().Length > 1)
            {
                Debug.LogError("There is more than one game controller in the scene");
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Invoke("playerPassedEvent", 2f);
        Invoke("playerPassedEvent", 4f);
        StartCoroutine("TimedBlockDrop");
    }


    //// Keyboard Controls-----------------------------------------------
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SingleLineClear();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SwitchGameSpeed();
        }

    }

    public void SubscribeScriptToGameEventUpdates(MonoBehaviour pScript)
    {
        eventSubscribedScripts.Add(pScript);
    }

    public void DeSubscribeScriptToGameEventUpdates(MonoBehaviour pScript)
    {
        while (eventSubscribedScripts.Contains(pScript))
        {
            eventSubscribedScripts.Remove(pScript);
        }
    }

    public void LinesClearedScriptToGC(MonoBehaviour pScript)
    {
        linesCleared = pScript;
    }

    public void PlayerScoreScriptToGC(MonoBehaviour pScript)
    {
        playerScore = pScript;
    }

    public void GameUIScriptToGC(MonoBehaviour pScript)
    {
        gameUI = pScript;
    }

    public void LevelScriptToGC(MonoBehaviour pScript)
    {
        level = pScript;
    }

    public void GameLogicScriptToGC(MonoBehaviour pScript)
    {
        gameLogic = pScript;
    }
    public void SoundScriptToGC(MonoBehaviour pScript)
    {
        soundEffects = pScript;
    }



    public void playerPassedEvent()
    {
        gameEventID++;
        foreach (MonoBehaviour _script in eventSubscribedScripts)
        {
            _script.Invoke("gameEventUpdated", 0);
            Debug.Log(_script.name + " is loaded");
        }
    }

    public void SingleLineClear()
    {
        playerScore.Invoke("SingleLineClear", 0);
        linesCleared.Invoke("SingleLineClear", 0);

    }

    public void DoubleLineClear()
    {
        playerScore.Invoke("DoubleLineClear", 0);
        linesCleared.Invoke("DoubleLineClear", 0);

    }

    public void TripleLineClear()
    {
        playerScore.Invoke("TripleLineClear", 0);
        linesCleared.Invoke("TripleLineClear", 0);

    }

    public void QuadLineClear()
    {
        playerScore.Invoke("QuadLineClear", 0);
        linesCleared.Invoke("QuadLineClear", 0);

    }

    public void nextLevel()
    {
        level.Invoke("nextLevel",0);
        SwitchGameSpeed();
    }

    void SwitchGameSpeed()
    {
        switch (gameSpeed)
        {
            case 1.0f:
                gameSpeed = .9f;
                break;
            case .9f:
                gameSpeed = .8f;
                break;
            case .8f:
                gameSpeed = .7f;
                break;
            case .7f:
                gameSpeed = .6f;
                break;
            case .6f:
                gameSpeed = .5f;
                break;
            case .5f:
                gameSpeed = .4f;
                break;
            case .4f:
                gameSpeed = .3f;
                break;
            case .3f:
                gameSpeed = .2f;
                break;
            case .2f:
                gameSpeed = .1f;
                break;
            case .1f:
                gameSpeed = .07f;
                break;
            case .07f:
                gameSpeed = .05f;
                break;
            case .05f:
                gameSpeed = .03f;
                break;
            case .03f:
                gameSpeed = 1.0f;
                break;
            default:
                break;
        }
    }

    IEnumerator TimedBlockDrop()
    {
        while (true)
        {
            yield return new WaitForSeconds(gameSpeed);
            gameLogic.Invoke("moveBlockDown", 0);
        }
    }
}
