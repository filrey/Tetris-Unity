using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Board
{
    // Start is called before the first frame update
    void Start()
    {
        //GameController.Instance.SubscribeScriptToGameEventUpdates(this);
        //GameController.Instance.MovementScriptToGC(this);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

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

    private void clearActiveCubes()
    {
        cube[board[activeCubes[0], activeCubes[1]]].GetComponent<Renderer>().material = defaultMat;
        cube[board[activeCubes[2], activeCubes[3]]].GetComponent<Renderer>().material = defaultMat;
        cube[board[activeCubes[4], activeCubes[5]]].GetComponent<Renderer>().material = defaultMat;
        cube[board[activeCubes[6], activeCubes[7]]].GetComponent<Renderer>().material = defaultMat;
    }

    private void colorActiveCubes()
    {
        cube[board[activeCubes[0], activeCubes[1]]].GetComponent<Renderer>().material.color = currentColor;
        cube[board[activeCubes[2], activeCubes[3]]].GetComponent<Renderer>().material.color = currentColor;
        cube[board[activeCubes[4], activeCubes[5]]].GetComponent<Renderer>().material.color = currentColor;
        cube[board[activeCubes[6], activeCubes[7]]].GetComponent<Renderer>().material.color = currentColor;
    }

    private void moveDown()
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

    private void moveUp()
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

    private void moveRight()
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

    private void moveleft()
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
}
