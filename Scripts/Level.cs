using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level : MonoBehaviour
{
    public int level = 1;
    public Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        GameController.Instance.LevelScriptToGC(this);

        levelText.text = level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
