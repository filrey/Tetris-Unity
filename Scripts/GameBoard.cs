using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameBoard : LinesCleared
{

    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        GameController.Instance.BoardScriptToGC(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void test()
    {
        Debug.Log("This is the GameBoard Child");
    }
}
