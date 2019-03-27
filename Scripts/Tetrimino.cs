using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Tetrimino : Board
{
    // Start is called before the first frame update
    void Start()
    {
        //GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        //GameController.Instance.TetriminoScriptToGC(this);
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

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

    private void moveTetrimino(GameObject cube1, GameObject cube2, GameObject cube3, GameObject cube4, bool useColor)
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

    private void chooseTetrimno(int shape)
    {

        int[] iCoor = new int[8] { 3, 0, 4, 0, 5, 0, 6, 0 };
        int[] jCoor = new int[8] { 3, 0, 4, 0, 5, 0, 3, 1 };
        int[] lCoor = new int[8] { 4, 0, 5, 0, 6, 0, 6, 1 };
        int[] oCoor = new int[8] { 4, 0, 5, 0, 4, 1, 5, 1 };
        int[] sCoor = new int[8] { 4, 0, 5, 0, 5, 1, 6, 1 };
        int[] tCoor = new int[8] { 3, 0, 4, 0, 5, 0, 4, 1 };
        int[] zCoor = new int[8] { 4, 0, 5, 0, 3, 1, 4, 1 };

        shapeState = 0;


        switch (shape)
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

    private void instantLock()
    {
        lockTetrimino(board[activeCubes[0], activeCubes[1]], board[activeCubes[2], activeCubes[3]], board[activeCubes[4], activeCubes[5]], board[activeCubes[6], activeCubes[7]]);
        NextTetrimino();
    }

    private void iBlock()
    {
        chooseTetrimno(1);
    }

    private void jBlock()
    {
        chooseTetrimno(2);
    }

    private void lBlock()
    {
        chooseTetrimno(3);
    }

    private void oBlock()
    {
        chooseTetrimno(4);
    }

    private void sBlock()
    {
        chooseTetrimno(5);
    }

    private void tBlock()
    {
        chooseTetrimno(6);
    }

    private void zBlock()
    {
        chooseTetrimno(7);
    }
}
