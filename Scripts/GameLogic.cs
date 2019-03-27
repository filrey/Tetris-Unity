using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class GameLogic : MonoBehaviour
{
    GameObject Root;
    GameObject[] cube = new GameObject[200];
    int[,] board = new int[10, 20];
    int[] activeCubes = new int[8] { 4, 0, 5, 0, 4, 1, 5, 1 };
    int[] occupied = new int[200];
    int currentShape = 3;
    int shapeState = 0;
    public Material defaultMat;

    Color currentColor = Color.yellow;
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        GameController.Instance.GameLogicScriptToGC(this);
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

        //First Block is made
        moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            bool collision = CheckCollision(activeCubes[1], activeCubes[3], activeCubes[5], activeCubes[7], 0);
            if (!collision)
            {
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], false);

                activeCubes[1]++;
                activeCubes[3]++;
                activeCubes[5]++;
                activeCubes[7]++;

                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
            }

            if (collision)
            {
                lockTetrimino(board[activeCubes[0], activeCubes[1]], board[activeCubes[2], activeCubes[3]], board[activeCubes[4], activeCubes[5]], board[activeCubes[6], activeCubes[7]]);
                NextTetrimino();
            }

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            bool collision = CheckCollision(activeCubes[1], activeCubes[3], activeCubes[5], activeCubes[7], 1);
            if (!collision)
            {
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], false);

                activeCubes[1]--;
                activeCubes[3]--;
                activeCubes[5]--;
                activeCubes[7]--;

                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
            }
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bool collision = CheckCollision(activeCubes[0], activeCubes[2], activeCubes[4], activeCubes[6], 2);
            if (!collision)
            {
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], false);

                activeCubes[0]--;
                activeCubes[2]--;
                activeCubes[4]--;
                activeCubes[6]--;

                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bool collision = CheckCollision(activeCubes[0], activeCubes[2], activeCubes[4], activeCubes[6], 3);
            if (!collision)
            {
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], false);

                activeCubes[0]++;
                activeCubes[2]++;
                activeCubes[4]++;
                activeCubes[6]++;

                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
            }
        }

        // Testing: Immediately lock tetrimino on pressing A
        if (Input.GetKeyDown(KeyCode.A))
        {
            lockTetrimino(board[activeCubes[0], activeCubes[1]], board[activeCubes[2], activeCubes[3]], board[activeCubes[4], activeCubes[5]], board[activeCubes[6], activeCubes[7]]);
            NextTetrimino();

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            showOccupiedCubes();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rotateCounterClockwise();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            rotateClockwise();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            chooseTetrimno(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            chooseTetrimno(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            chooseTetrimno(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            chooseTetrimno(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            chooseTetrimno(5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            chooseTetrimno(6);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            chooseTetrimno(7);
        }
    }

    private void rotateCounterClockwise()
    {
        // Rotations for i Block
        if (currentShape == 0)
        {
            int[] subBoardX = new int[4];
            int[] subBoardY = new int[4];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;
                    subBoardX[3] = activeX + 3;


                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;
                    subBoardY[3] = activeY + 3;

                    reasignActiveCubes(1, 3, 1, 2, 1, 1, 1, 0, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2] + subBoardX[3]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2] + subBoardY[3]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;
                    subBoardX[3] = activeX + 2;


                    subBoardY[0] = activeY - 3;
                    subBoardY[1] = activeY - 2;
                    subBoardY[2] = activeY - 1;
                    subBoardY[3] = activeY;

                    reasignActiveCubes(0, 1, 1, 1, 2, 1, 3, 1, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2] + subBoardX[3]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2] + subBoardY[3]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        // Rotation for j Block
        if (currentShape == 1)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(0, 0, 1, 0, 1, 1, 1, 2, subBoardX, subBoardY);

                    shapeState = 3;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY - 2;
                    subBoardY[1] = activeY - 1;
                    subBoardY[2] = activeY;

                    reasignActiveCubes(0, 0, 1, 0, 2, 0, 0, 1, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 2:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY - 1;
                    subBoardY[1] = activeY;
                    subBoardY[2] = activeY + 1;

                    reasignActiveCubes(2, 2, 1, 2, 1, 1, 1, 0, subBoardX, subBoardY);


                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 3:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(2, 1, 2, 2, 1, 2, 0, 2, subBoardX, subBoardY);


                    shapeState = 2;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        //Rotations for L Block
        if (currentShape == 2)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(0, 2, 1, 2, 1, 1, 1, 0, subBoardX, subBoardY);
                    shapeState = 3;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(0, 1, 1, 1, 2, 1, 2, 2, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 2:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY - 2;
                    subBoardY[1] = activeY - 1;
                    subBoardY[2] = activeY;

                    reasignActiveCubes(2, 0, 1, 0, 1, 1, 1, 2, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 3:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY - 2;
                    subBoardY[1] = activeY - 1;
                    subBoardY[2] = activeY;

                    reasignActiveCubes(2, 2, 1, 2, 0, 2, 0, 1, subBoardX, subBoardY);

                    shapeState = 2;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        //Rotations for s block
        if (currentShape == 4)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(2, 0, 2, 1, 1, 1, 1, 2, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(0, 1, 1, 1, 1, 2, 2, 2, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        //Rotations for t block
        if (currentShape == 5)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:

                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    activeCubes[0] = subBoardX[1];
                    activeCubes[1] = subBoardY[0];
                    activeCubes[2] = subBoardX[1];
                    activeCubes[3] = subBoardY[1];
                    activeCubes[4] = subBoardX[1];
                    activeCubes[5] = subBoardY[2];
                    activeCubes[6] = subBoardX[0];
                    activeCubes[7] = subBoardY[1];

                    shapeState = 3;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();

                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    activeCubes[0] = subBoardX[0];
                    activeCubes[1] = subBoardY[0];
                    activeCubes[2] = subBoardX[1];
                    activeCubes[3] = subBoardY[0];
                    activeCubes[4] = subBoardX[2];
                    activeCubes[5] = subBoardY[0];
                    activeCubes[6] = subBoardX[1];
                    activeCubes[7] = subBoardY[1];

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 2:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY - 2;
                    subBoardY[1] = activeY - 1;
                    subBoardY[2] = activeY;

                    activeCubes[0] = subBoardX[1];
                    activeCubes[1] = subBoardY[0];
                    activeCubes[2] = subBoardX[1];
                    activeCubes[3] = subBoardY[1];
                    activeCubes[4] = subBoardX[1];
                    activeCubes[5] = subBoardY[2];
                    activeCubes[6] = subBoardX[2];
                    activeCubes[7] = subBoardY[1];

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 3:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    activeCubes[0] = subBoardX[2];
                    activeCubes[1] = subBoardY[2];
                    activeCubes[2] = subBoardX[1];
                    activeCubes[3] = subBoardY[2];
                    activeCubes[4] = subBoardX[0];
                    activeCubes[5] = subBoardY[2];
                    activeCubes[6] = subBoardX[1];
                    activeCubes[7] = subBoardY[1];

                    shapeState = 2;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        //Rotations for z block
        if (currentShape == 6)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;

                    subBoardY[0] = activeY - 1;
                    subBoardY[1] = activeY;
                    subBoardY[2] = activeY + 1;

                    reasignActiveCubes(1, 2, 1, 1, 0, 1, 0, 0, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;

                    subBoardY[0] = activeY - 1;
                    subBoardY[1] = activeY;
                    subBoardY[2] = activeY + 1;

                    reasignActiveCubes(1, 1, 2, 1, 1, 2, 0, 2, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
    }

    private void rotateClockwise()
    {
        // Rotations for i Block
        if (currentShape == 0)
        {
            int[] subBoardX = new int[4];
            int[] subBoardY = new int[4];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;
                    subBoardX[3] = activeX + 3;


                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;
                    subBoardY[3] = activeY + 3;

                    reasignActiveCubes(1, 3, 1, 2, 1, 1, 1, 0, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2] + subBoardX[3]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2] + subBoardY[3]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;
                    subBoardX[3] = activeX + 2;


                    subBoardY[0] = activeY - 3;
                    subBoardY[1] = activeY - 2;
                    subBoardY[2] = activeY - 1;
                    subBoardY[3] = activeY;

                    reasignActiveCubes(0, 1, 1, 1, 2, 1, 3, 1, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2] + subBoardX[3]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2] + subBoardY[3]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        // Rotation for j Block
        if (currentShape == 1)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(2, 2, 1, 2, 1, 1, 1, 0, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY - 2;
                    subBoardY[1] = activeY - 1;
                    subBoardY[2] = activeY;

                    reasignActiveCubes(2, 1, 2, 2, 1, 2, 0, 2, subBoardX, subBoardY);

                    shapeState = 2;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 2:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY - 1;
                    subBoardY[1] = activeY;
                    subBoardY[2] = activeY + 1;

                    reasignActiveCubes(0, 0, 1, 0, 1, 1, 1, 2, subBoardX, subBoardY);

                    shapeState = 3;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 3:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(0, 0, 1, 0, 2, 0, 0, 1, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        //Rotations for L Block
        if (currentShape == 2)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(2, 0, 1, 0, 1, 1, 1, 2, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(2, 2, 1, 2, 0, 2, 0, 1, subBoardX, subBoardY);

                    shapeState = 2;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 2:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY - 2;
                    subBoardY[1] = activeY - 1;
                    subBoardY[2] = activeY;

                    reasignActiveCubes(0, 2, 1, 2, 1, 1, 1, 0, subBoardX, subBoardY);

                    shapeState = 3;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 3:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY - 2;
                    subBoardY[1] = activeY - 1;
                    subBoardY[2] = activeY;

                    reasignActiveCubes(0, 1, 1, 1, 2, 1, 2, 2, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        //Rotations for s block
        if (currentShape == 4)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(2, 0, 2, 1, 1, 1, 1, 2, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    reasignActiveCubes(0, 1, 1, 1, 1, 2, 2, 2, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        //Rotations for t block
        if (currentShape == 5)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:

                    clearActiveCubes();

                    subBoardX[0] = activeX;
                    subBoardX[1] = activeX + 1;
                    subBoardX[2] = activeX + 2;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    activeCubes[0] = subBoardX[1];
                    activeCubes[1] = subBoardY[0];
                    activeCubes[2] = subBoardX[1];
                    activeCubes[3] = subBoardY[1];
                    activeCubes[4] = subBoardX[1];
                    activeCubes[5] = subBoardY[2];
                    activeCubes[6] = subBoardX[2];
                    activeCubes[7] = subBoardY[1];

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();

                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    activeCubes[0] = subBoardX[2];
                    activeCubes[1] = subBoardY[2];
                    activeCubes[2] = subBoardX[1];
                    activeCubes[3] = subBoardY[2];
                    activeCubes[4] = subBoardX[0];
                    activeCubes[5] = subBoardY[2];
                    activeCubes[6] = subBoardX[1];
                    activeCubes[7] = subBoardY[1];

                    shapeState = 2;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 2:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 2;
                    subBoardX[1] = activeX - 1;
                    subBoardX[2] = activeX;

                    subBoardY[0] = activeY - 2;
                    subBoardY[1] = activeY - 1;
                    subBoardY[2] = activeY;

                    activeCubes[0] = subBoardX[1];
                    activeCubes[1] = subBoardY[0];
                    activeCubes[2] = subBoardX[1];
                    activeCubes[3] = subBoardY[1];
                    activeCubes[4] = subBoardX[1];
                    activeCubes[5] = subBoardY[2];
                    activeCubes[6] = subBoardX[0];
                    activeCubes[7] = subBoardY[1];

                    shapeState = 3;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 3:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;

                    subBoardY[0] = activeY;
                    subBoardY[1] = activeY + 1;
                    subBoardY[2] = activeY + 2;

                    activeCubes[0] = subBoardX[0];
                    activeCubes[1] = subBoardY[0];
                    activeCubes[2] = subBoardX[1];
                    activeCubes[3] = subBoardY[0];
                    activeCubes[4] = subBoardX[2];
                    activeCubes[5] = subBoardY[0];
                    activeCubes[6] = subBoardX[1];
                    activeCubes[7] = subBoardY[1];

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
        //Rotations for z block
        if (currentShape == 6)
        {
            int[] subBoardX = new int[3];
            int[] subBoardY = new int[3];
            int activeX = activeCubes[0];
            int activeY = activeCubes[1];

            switch (shapeState)
            {
                case 0:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;

                    subBoardY[0] = activeY - 1;
                    subBoardY[1] = activeY;
                    subBoardY[2] = activeY + 1;

                    reasignActiveCubes(1, 2, 1, 1, 0, 1, 0, 0, subBoardX, subBoardY);

                    shapeState = 1;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                case 1:
                    clearActiveCubes();

                    subBoardX[0] = activeX - 1;
                    subBoardX[1] = activeX;
                    subBoardX[2] = activeX + 1;

                    subBoardY[0] = activeY - 1;
                    subBoardY[1] = activeY;
                    subBoardY[2] = activeY + 1;

                    reasignActiveCubes(1, 1, 2, 1, 1, 2, 0, 2, subBoardX, subBoardY);

                    shapeState = 0;

                    Debug.Log("subBoardX: " + subBoardX[0] + subBoardX[1] + subBoardX[2]);
                    Debug.Log("subBoardY: " + subBoardY[0] + subBoardY[1] + subBoardY[2]);
                    Debug.Log("Activecubes [0-7]: " + activeCubes[0] + activeCubes[1] + activeCubes[2] + activeCubes[3] + activeCubes[4] + activeCubes[5] + activeCubes[6] + activeCubes[7]);

                    colorActiveCubes();
                    break;
                default:
                    break;
            }
        }
    }

    private void reasignActiveCubes(int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8, int[] subBoardX, int[] subBoardY)
    {
        activeCubes[0] = subBoardX[v1];
        activeCubes[1] = subBoardY[v2];
        activeCubes[2] = subBoardX[v3];
        activeCubes[3] = subBoardY[v4];
        activeCubes[4] = subBoardX[v5];
        activeCubes[5] = subBoardY[v6];
        activeCubes[6] = subBoardX[v7];
        activeCubes[7] = subBoardY[v8];
    }

    private void colorActiveCubes()
    {
        cube[board[activeCubes[0], activeCubes[1]]].GetComponent<Renderer>().material.color = currentColor;
        cube[board[activeCubes[2], activeCubes[3]]].GetComponent<Renderer>().material.color = currentColor;
        cube[board[activeCubes[4], activeCubes[5]]].GetComponent<Renderer>().material.color = currentColor;
        cube[board[activeCubes[6], activeCubes[7]]].GetComponent<Renderer>().material.color = currentColor;
    }

    private void clearActiveCubes()
    {
        cube[board[activeCubes[0], activeCubes[1]]].GetComponent<Renderer>().material = defaultMat;
        cube[board[activeCubes[2], activeCubes[3]]].GetComponent<Renderer>().material = defaultMat;
        cube[board[activeCubes[4], activeCubes[5]]].GetComponent<Renderer>().material = defaultMat;
        cube[board[activeCubes[6], activeCubes[7]]].GetComponent<Renderer>().material = defaultMat;
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

    // integer direction dictates which way to check 0: down, 1: up, 2: left, 3: right
    private bool CheckCollision(int cubeCoor1, int cubeCoor2, int cubeCoor3, int cubeCoor4, int direction)
    {
        int isCubeOccupied1, isCubeOccupied2, isCubeOccupied3, isCubeOccupied4;
        if (direction == 0)
        {
            if (activeCubes[1] != 19 && activeCubes[3] != 19 && activeCubes[5] != 19 && activeCubes[7] != 19)
            {
                cubeCoor1++; cubeCoor2++; cubeCoor3++; cubeCoor4++;
                isCubeOccupied1 = occupied[board[activeCubes[0], cubeCoor1]];
                isCubeOccupied2 = occupied[board[activeCubes[2], cubeCoor2]];
                isCubeOccupied3 = occupied[board[activeCubes[4], cubeCoor3]];
                isCubeOccupied4 = occupied[board[activeCubes[6], cubeCoor4]];

                // IF Locked tetrimino exists when moving down then collision is true and current tetrimino should be locked
                if (isCubeOccupied1 == 1 || isCubeOccupied2 == 1 || isCubeOccupied3 == 1 || isCubeOccupied4 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (activeCubes[1] == 19 || activeCubes[3] == 19 || activeCubes[5] == 19 || activeCubes[7] == 19)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if (direction == 1)
        {
            if (activeCubes[1] != 19 && activeCubes[3] != 19 && activeCubes[5] != 19 && activeCubes[7] != 19)
            {
                cubeCoor1--; cubeCoor2--; cubeCoor3--; cubeCoor4--;
                isCubeOccupied1 = occupied[board[activeCubes[0], cubeCoor1]];
                isCubeOccupied2 = occupied[board[activeCubes[2], cubeCoor2]];
                isCubeOccupied3 = occupied[board[activeCubes[4], cubeCoor3]];
                isCubeOccupied4 = occupied[board[activeCubes[6], cubeCoor4]];

                // IF Locked tetrimino exists when moving down then collision is true and current tetrimino should be locked
                if (isCubeOccupied1 == 1 || isCubeOccupied2 == 1 || isCubeOccupied3 == 1 || isCubeOccupied4 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (activeCubes[1] == 19 || activeCubes[3] == 19 || activeCubes[5] == 19 || activeCubes[7] == 19)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (direction == 2)
        {
            if (activeCubes[0] != 0 && activeCubes[2] != 0 && activeCubes[4] != 0 && activeCubes[6] != 0)
            {
                cubeCoor1--; cubeCoor2--; cubeCoor3--; cubeCoor4--;
                isCubeOccupied1 = occupied[board[cubeCoor1, activeCubes[1]]];
                isCubeOccupied2 = occupied[board[cubeCoor2, activeCubes[3]]];
                isCubeOccupied3 = occupied[board[cubeCoor3, activeCubes[5]]];
                isCubeOccupied4 = occupied[board[cubeCoor4, activeCubes[7]]];

                // IF Locked tetrimino exists when moving down then collision is true and current tetrimino should be locked
                if (isCubeOccupied1 == 1 || isCubeOccupied2 == 1 || isCubeOccupied3 == 1 || isCubeOccupied4 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (activeCubes[0] == 0 || activeCubes[2] == 0 || activeCubes[4] == 0 || activeCubes[6] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (direction == 3)
        {
            if (activeCubes[0] != 9 && activeCubes[2] != 9 && activeCubes[4] != 9 && activeCubes[6] != 9)
            {
                cubeCoor1++; cubeCoor2++; cubeCoor3++; cubeCoor4++;
                isCubeOccupied1 = occupied[board[cubeCoor1, activeCubes[1]]];
                isCubeOccupied2 = occupied[board[cubeCoor2, activeCubes[3]]];
                isCubeOccupied3 = occupied[board[cubeCoor3, activeCubes[5]]];
                isCubeOccupied4 = occupied[board[cubeCoor4, activeCubes[7]]];

                // IF Locked tetrimino exists when moving down then collision is true and current tetrimino should be locked
                if (isCubeOccupied1 == 1 || isCubeOccupied2 == 1 || isCubeOccupied3 == 1 || isCubeOccupied4 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (activeCubes[0] == 9 || activeCubes[2] == 9 || activeCubes[4] == 9 || activeCubes[6] == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
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

    private void lockTetrimino(int cube1, int cube2, int cube3, int cube4)
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

    private void checkForLineClear(int cube1, int cube2, int cube3, int cube4)
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

    public void moveBlockDown()
    {
        bool collision = CheckCollision(activeCubes[1], activeCubes[3], activeCubes[5], activeCubes[7], 0);
        if (!collision)
        {
            moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                  cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], false);

            activeCubes[1]++;
            activeCubes[3]++;
            activeCubes[5]++;
            activeCubes[7]++;

            moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                  cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
        }

        if (collision)
        {
            lockTetrimino(board[activeCubes[0], activeCubes[1]], board[activeCubes[2], activeCubes[3]], board[activeCubes[4], activeCubes[5]], board[activeCubes[6], activeCubes[7]]);
            NextTetrimino();
        }
    }
}
