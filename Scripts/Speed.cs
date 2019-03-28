using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        //GameController.Instance.SpeedScriptToGC(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
