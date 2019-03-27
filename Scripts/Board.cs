using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

// Board contains all global variables for the game
public class Board : MonoBehaviour
{
    GameObject Root;
    public GameObject[] cube = new GameObject[200];
    public int[,] board = new int[10, 20];
    public int[] activeCubes = new int[8] { 4, 0, 5, 0, 4, 1, 5, 1 };
    public int[] occupied = new int[200];
    public int currentShape = 3;
    public int shapeState = 0;
    public Color currentColor = Color.yellow;
    public Material defaultMat;


    // Start is called before the first frame update
    void Start()
    {
        //GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        //GameController.Instance.BoardScriptToGC(this);
        Root = new GameObject("Game Board");
        int counter = 0;

        for (int i = 0; i < board.GetLength(0); i++)
        {

            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = counter;
                occupied[counter] = 0;

                cube[counter] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube[counter].transform.SetParent(Root.transform);
                cube[counter].transform.position = new Vector3(i, j, 0);
                cube[counter].GetComponent<Renderer>().material = defaultMat;
                counter++;

            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void checkForLineClear(int cube1, int cube2, int cube3, int cube4)
    {
        clearLine(1);
        clearLine(3);
        clearLine(5);
        clearLine(7);

    }

    private void clearLine(int v)
    {
        int rowToCheck = activeCubes[v];
        int[] occupiedRow = new int[10];
        int count = 0;
        GameObject[] cubeRow = new GameObject[10];

        for (int i = 0; i < cubeRow.Length; i++)
        {
            cubeRow[i] = cube[board[i, rowToCheck]];
            occupiedRow[i] = occupied[board[i, rowToCheck]];
        }

        for (int i = 0; i < occupiedRow.Length; i++)
        {
            if (occupiedRow[i] == 1)
            {
                count++;
            }
        }

        if (count == 10)
        {
            for (int i = 0; i < cubeRow.Length; i++)
            {
                cubeRow[i].GetComponent<Renderer>().material = defaultMat;
                occupied[board[i, rowToCheck]] = 0;
            }
            dropStack(rowToCheck);
            GameController.Instance.SingleLineClear();
        }
    }

    private void dropStack(int row)
    {
        for (int j = row; j > 0; j--)
        {
            for (int i = 0; i < 10; i++)
            {
                cube[board[i, j]].GetComponent<Renderer>().material.color = cube[board[i, j - 1]].GetComponent<Renderer>().material.color;
                cube[board[i, j - 1]].GetComponent<Renderer>().material = defaultMat;

                occupied[board[i, j]] = occupied[board[i, j - 1]];
                // Debug.Log("Row is:" + row);

            }
        }
    }

    private void showOccupiedCubes()
    {
        Debug.Log("Displaying Occupied Cubes... ");
        for (int i = 0; i < occupied.Length; i++)
        {
            if (occupied[i] == 1)
            {
                cube[i].GetComponent<Renderer>().material.color = Color.grey;
            }
        }
    }

    public void NextTetrimino()
    {
        Random r = new Random();
        int rInt = r.Next(1, 8);

        int[] iCoor = new int[8] { 3, 0, 4, 0, 5, 0, 6, 0 };
        int[] jCoor = new int[8] { 3, 0, 4, 0, 5, 0, 3, 1 };
        int[] lCoor = new int[8] { 4, 0, 5, 0, 6, 0, 6, 1 };
        int[] oCoor = new int[8] { 4, 0, 5, 0, 4, 1, 5, 1 };
        int[] sCoor = new int[8] { 4, 0, 5, 0, 5, 1, 6, 1 };
        int[] tCoor = new int[8] { 3, 0, 4, 0, 5, 0, 4, 1 };
        int[] zCoor = new int[8] { 4, 0, 5, 0, 3, 1, 4, 1 };

        shapeState = 0;


        switch (rInt)
        {
            case 1:
                currentColor = Color.cyan;
                activeCubes = iCoor;
                currentShape = 0;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 2:
                currentColor = Color.blue;
                activeCubes = jCoor;
                currentShape = 1;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 3:
                currentColor = Color.white;
                activeCubes = lCoor;
                currentShape = 2;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 4:
                currentColor = Color.yellow;
                activeCubes = oCoor;
                currentShape = 3;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 5:
                currentColor = Color.green;
                activeCubes = sCoor;
                currentShape = 4;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 6:
                currentColor = Color.magenta;
                activeCubes = tCoor;
                currentShape = 5;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 7:
                currentColor = Color.red;
                activeCubes = zCoor;
                currentShape = 6;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            default:
                break;
        }

    }

    public void lockTetrimino(int cube1, int cube2, int cube3, int cube4)
    {
        occupied[cube1] = 1;
        occupied[cube2] = 1;
        occupied[cube3] = 1;
        occupied[cube4] = 1;

        Debug.Log("Locked: [" + cube1 + "]" + " [" + cube2 + "]" + " [" + cube3 + "]" + " [" + cube4 + "]");

        checkForLineClear(cube1, cube2, cube3, cube4);

        // For testing Purposes locked tetriminos are turned grey
        //cube[cube1].GetComponent<Renderer>().material.color = Color.grey;
        //cube[cube2].GetComponent<Renderer>().material.color = Color.grey;
        //cube[cube3].GetComponent<Renderer>().material.color = Color.grey;
        //cube[cube4].GetComponent<Renderer>().material.color = Color.grey;
    }

    public void moveTetrimino(GameObject cube1, GameObject cube2, GameObject cube3, GameObject cube4, bool useColor)
    {
        if (useColor)
        {
            // cube1.GetComponent<Renderer>().material.color = Color.red;
            // cube2.GetComponent<Renderer>().material.color = Color.yellow;
            // cube3.GetComponent<Renderer>().material.color = Color.blue;
            // cube4.GetComponent<Renderer>().material.color = Color.green;

            cube1.GetComponent<Renderer>().material.color = currentColor;
            cube2.GetComponent<Renderer>().material.color = currentColor;
            cube3.GetComponent<Renderer>().material.color = currentColor;
            cube4.GetComponent<Renderer>().material.color = currentColor;
        }
        else
        {
            cube1.GetComponent<Renderer>().material = defaultMat;
            cube2.GetComponent<Renderer>().material = defaultMat;
            cube3.GetComponent<Renderer>().material = defaultMat;
            cube4.GetComponent<Renderer>().material = defaultMat;
        }
    }



}
