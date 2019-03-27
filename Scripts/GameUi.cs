using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        GameController.Instance.GameUIScriptToGC(this);

    }

    //void OnDestroy()
    //{
    //    GameController.Instance.deSubscribeScriptToGameEventUpdates(this);
    //}

    //This method will be automatically called when the player passes an importnat important in the game
    void gameEventUpdated()
    {
        Debug.Log("GameUI: gameEventUpdated");
        if(GameController.Instance.gameEventID == 2)
        {
            // run an event
            Debug.Log("Run the dance animation");

        }
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
