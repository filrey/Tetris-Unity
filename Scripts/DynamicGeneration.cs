using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicGeneration : MonoBehaviour
{
    GameObject Root;
    GameObject[] cube = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        Root = new GameObject("IRoot-Dynamic");
        for (int i = 0; i < 4; i++)
        {
            cube[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube[i].transform.SetParent(Root.transform);
            cube[i].transform.position = new Vector3(i, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Root.transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Root.transform.Translate(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Root.transform.Rotate(Vector3.forward, 90);
        }
    }
}
