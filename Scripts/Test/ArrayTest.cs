using System;
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


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            bool collision = CheckCollisionDown(activeCubes[1], activeCubes[3], activeCubes[5], activeCubes[7],0);
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
            bool collision = CheckCollisionDown(activeCubes[1], activeCubes[3], activeCubes[5], activeCubes[7], 1);
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
            if (activeCubes[0] != 0 && activeCubes[2] != 0 && activeCubes[4] != 0 && activeCubes[6] != 0)
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
            if (activeCubes[0] != 9 && activeCubes[2] != 9 && activeCubes[4] != 9 && activeCubes[6] != 9)
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
    }

    // integer direction dictates which way to check 0: down, 1: up, 2: left, 3: right
    private bool CheckCollisionDown(int cubeCoor1, int cubeCoor2, int cubeCoor3, int cubeCoor4, int direction)
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
            return false;
        }
        if (direction == 3)
        {
            return false;
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


        switch (rInt)
        {
            case 1:
                currentColor = Color.cyan;
                activeCubes = iCoor;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 2:
                currentColor = Color.blue;
                activeCubes = jCoor;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 3:
                currentColor = Color.white;
                activeCubes = lCoor;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 4:
                currentColor = Color.yellow;
                activeCubes = oCoor;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 5:
                currentColor = Color.green;
                activeCubes = sCoor;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 6:
                currentColor = Color.magenta;
                activeCubes = tCoor;
                moveTetrimino(cube[board[activeCubes[0], activeCubes[1]]], cube[board[activeCubes[2], activeCubes[3]]],
                      cube[board[activeCubes[4], activeCubes[5]]], cube[board[activeCubes[6], activeCubes[7]]], true);
                break;
            case 7:
                currentColor = Color.red;
                activeCubes = zCoor;
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

        // For testing Purposes locked tetriminos are turned grey
        //cube[cube1].GetComponent<Renderer>().material.color = Color.grey;
        //cube[cube2].GetComponent<Renderer>().material.color = Color.grey;
        //cube[cube3].GetComponent<Renderer>().material.color = Color.grey;
        //cube[cube4].GetComponent<Renderer>().material.color = Color.grey;
    }
}
