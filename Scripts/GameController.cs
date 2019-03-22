using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<MonoBehaviour> eventSubscribedScripts = new List<MonoBehaviour>();
    public MonoBehaviour playerScore;
    public MonoBehaviour linesCleared;

    public int gameEventID = 0;
    //public int playerScore;
    //public int linesCleared = 0;
    public int level = 0;
    public int speed = 0;

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
    }


    //// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SingleLineClear();

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
}
