using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<MonoBehaviour> eventSubscribedScripts = new List<MonoBehaviour>();
    public MonoBehaviour playerScore;
    public MonoBehaviour linesCleared;
    public MonoBehaviour board;
    public MonoBehaviour speed;
    //public MonoBehaviour tetrimino;
    //public MonoBehaviour movement;
    public MonoBehaviour gameLogic;





    public int gameEventID = 0;
    //public int playerScore;
    //public int linesCleared = 0;
    public int level = 0;
    public float gameSpeed = 1;

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
        InvokeRepeating("TimedBlockDrop", 1.0f, .3f);
    }


    //// Keyboard Controls-----------------------------------------------
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SingleLineClear();
        }

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    movement.Invoke("moveDown", 0);
        //}

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    movement.Invoke("moveUp", 0);
        //}


        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    movement.Invoke("moveRight", 0);
        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    movement.Invoke("moveLeft", 0);
        //}

        //// Testing: Immediately lock tetrimino on pressing A
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    tetrimino.Invoke("instantLock", 0);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    board.Invoke("showOccupiedCubes", 0);

        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    movement.Invoke("rotateCounterClockwise", 0);

        //}

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    movement.Invoke("rotateClockwise", 0);

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    tetrimino.Invoke("iBlock", 0);

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    tetrimino.Invoke("jBlock", 0);

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    tetrimino.Invoke("lBlock", 0);

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    tetrimino.Invoke("oBlock", 0);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    tetrimino.Invoke("sBlock", 0);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    tetrimino.Invoke("tBlock", 0);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha7))
        //{
        //    tetrimino.Invoke("zBlock", 0);
        //}
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

    public void BoardScriptToGC(MonoBehaviour pScript)
    {
        board = pScript;
    }

    public void SpeedScriptToGC(MonoBehaviour pScript)
    {
        speed = pScript;
    }

    //public void TetriminoScriptToGC(MonoBehaviour pScript)
    //{
    //    tetrimino = pScript;
    //}

    //public void MovementScriptToGC(MonoBehaviour pScript)
    //{
    //    movement = pScript;
    //}

    public void GameLogicScriptToGC(MonoBehaviour pScript)
    {
        gameLogic = pScript;
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

    void TimedBlockDrop()
    {
        gameLogic.Invoke("moveBlockDown", 0);
    }
}
