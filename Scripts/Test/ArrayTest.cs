﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class ArrayTest : MonoBehaviour
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
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]],true);
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            bool collision = CheckCollision(activeCubes[1], activeCubes[3], activeCubes[5], activeCubes[7],0);
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
        if(Input.GetKeyDown(KeyCode.A))
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
    }

    private void rotateClockwise()
    {
        int cubeToCheck1;
        int cubeToCheck2;
        int[,] subBoard = new int[3,3];
        int rootCube = board[activeCubes[0], activeCubes[1]];
        bool collision = false;

        if (currentShape ==5)
        {
            //[111]
            //[010]
            //[010]
            if (shapeState==0)
            {
                subBoard[0, 0] = rootCube;
                subBoard[1, 0] = rootCube + 20;
                subBoard[2, 0] = rootCube + 40;

                subBoard[0, 1] = rootCube + 1;
                subBoard[1, 1] = rootCube + 21;
                subBoard[2, 1] = rootCube + 41;

                subBoard[0, 2] = rootCube + 2;
                subBoard[1, 2] = rootCube + 22;
                subBoard[2, 2] = rootCube + 42;

                cubeToCheck1 = subBoard[1, 2];
                cubeToCheck2 = subBoard[2, 1];

                rotateTetrimino(subBoard,cubeToCheck1,cubeToCheck2);


            }
            //[010]
            //[110]
            //[010]
            //if (shapeState == 1)
            //{
            //    subBoard[0, 0] = rootCube -20;
            //    subBoard[1, 0] = rootCube;
            //    subBoard[2, 0] = rootCube + 20;

            //    subBoard[0, 1] = subBoard[0, 0] + 1;
            //    subBoard[1, 1] = subBoard[1, 0] + 1;
            //    subBoard[2, 1] = subBoard[2, 0] + 1;

            //    subBoard[0, 2] = subBoard[0, 1] + 1;
            //    subBoard[1, 2] = subBoard[1, 1] + 1;
            //    subBoard[2, 2] = subBoard[2, 1] + 1;

            //    cubeToCheck1 = subBoard[0, 2];
            //    cubeToCheck2 = subBoard[2, 2];

            //    rotateTetrimino(subBoard, cubeToCheck1, cubeToCheck2);


            //}

            //if (shapeState == 2)
            //{
            //    subBoard[0, 0] = rootCube;
            //    subBoard[1, 0] = rootCube + 20;
            //    subBoard[2, 0] = rootCube + 40;

            //    subBoard[0, 1] = rootCube + 1;
            //    subBoard[1, 1] = rootCube + 21;
            //    subBoard[2, 1] = rootCube + 41;

            //    subBoard[0, 2] = rootCube + 2;
            //    subBoard[1, 2] = rootCube + 22;
            //    subBoard[2, 2] = rootCube + 42;

            //    cubeToCheck1 = subBoard[1, 2];
            //    cubeToCheck2 = subBoard[2, 1];

            //    rotateTetrimino(subBoard, cubeToCheck1, cubeToCheck2);


            //}

            //if (shapeState == 3)
            //{
            //    subBoard[0, 0] = rootCube;
            //    subBoard[1, 0] = rootCube + 20;
            //    subBoard[2, 0] = rootCube + 40;

            //    subBoard[0, 1] = rootCube + 1;
            //    subBoard[1, 1] = rootCube + 21;
            //    subBoard[2, 1] = rootCube + 41;

            //    subBoard[0, 2] = rootCube + 2;
            //    subBoard[1, 2] = rootCube + 22;
            //    subBoard[2, 2] = rootCube + 42;

            //    cubeToCheck1 = subBoard[1, 2];
            //    cubeToCheck2 = subBoard[2, 1];

            //    rotateTetrimino(subBoard, cubeToCheck1, cubeToCheck2);


            //}
        }
    }

    private void rotateTetrimino(int[,] subBoard, int cubeToCheck1, int cubeToCheck2)
    {
        GameObject[] cubes = new GameObject[9];
        int counter = 0;
        bool collision = occupied[cubeToCheck1] == 1 || occupied[cubeToCheck2] == 1;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                cubes[counter] = cube[subBoard[x, y]];
                counter++;
            }
        }

        if (currentShape ==5 && !collision)
        {
            if (shapeState == 0)
            {
                for (int x = 0; x < cubes.Length; x++)
                {
                    cubes[x].GetComponent<Renderer>().material = defaultMat;
                }
                // Cube 1
                activeCubes[0]++;
                // Cube 2
                activeCubes[3]++;
                // Cube 3
                activeCubes[4]--;
                activeCubes[5]+=2;
                // Cube 4
                activeCubes[6]++;

                shapeState = 1;

                cubes[3].GetComponent<Renderer>().material.color = currentColor;
                cubes[4].GetComponent<Renderer>().material.color = currentColor;
                cubes[5].GetComponent<Renderer>().material.color = currentColor;
                cubes[7].GetComponent<Renderer>().material.color = currentColor;

            }

            //if (shapeState == 1)
            //{
            //    for (int x = 0; x < cubes.Length; x++)
            //    {
            //        cubes[x].GetComponent<Renderer>().material = defaultMat;
            //    }
            //    // Cube 1
            //    activeCubes[0]++;
            //    activeCubes[1]+=2;
            //    // Cube 2
            //    activeCubes[3]++;
            //    // Cube 3
            //    activeCubes[4]--;
            //    // Cube 4
            //    activeCubes[6]++;

            //    shapeState = 2;
            //    //[630]
            //    //[741]
            //    //[852]
            //    cubes[8].GetComponent<Renderer>().material.color = currentColor;
            //    cubes[5].GetComponent<Renderer>().material.color = currentColor;
            //    cubes[2].GetComponent<Renderer>().material.color = currentColor;
            //    cubes[4].GetComponent<Renderer>().material.color = currentColor;

            //}
        }
    }


    private bool checkRotationCollision(int[] cubeToCheck1, int[] cubeToCheck2)
    {
        int cube1 = occupied[board[cubeToCheck1[0], cubeToCheck1[1]]];
        int cube2 = occupied[board[cubeToCheck2[0], cubeToCheck2[1]]];

        if (cube1 == 1 || cube2 == 1)
        {
            return true;
        }
        else
            return false;

    }

    private void rotateCounterClockwise()
    {
        throw new NotImplementedException();
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
        if(direction == 0)
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

        Debug.Log("Locked: ["+cube1+"]"+" ["+cube2+"]" + " [" + cube3+"]" + " [" + cube4+"]");

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
