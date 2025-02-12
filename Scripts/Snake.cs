using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Apple apple;
    public int SnakeBodySize;
    public List<Vector3> SnakeMovePositionList;
    public static bool GameOn { get; set; }
    public Material tail_material;
    
    float interval = 0.2f;
    float nextTime;
    int diary = 0;
    int step_counter = -1;
    float alpha = 0;                                                    //angle; direction of snake moving

    void Awake()
    {
        nextTime = Time.time + 0.4f;
    }

    void Update()
    {
        for (; Time.time >= nextTime;)                                  //1px step per "interval" logic
        {
            nextTime += interval;

            if (GameOn == false)
            {
                break;
            }

            // LEVELS: here interval increases per SnakeMovePositionList.Count can be implemented

            step_counter++;
            SnakeMovePositionList.Insert(0, transform.position);        //add snakes' coordinates on 1st position of the list
            
            if (SnakeMovePositionList.Count >= SnakeBodySize + 1)       //if snake does not grown in this turn, coordinates are remove immediately
            {
                SnakeMovePositionList.RemoveAt(SnakeMovePositionList.Count - 1);
            }

            for (int i = 0; i < SnakeMovePositionList.Count; i++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.GetComponent<MeshRenderer>().material = tail_material;
                cube.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                cube.GetComponent<BoxCollider>().enabled = false;
                cube.transform.localPosition = SnakeMovePositionList[i];
                GameObject.Destroy(cube, interval);
            }

            transform.position += transform.forward;

            if (Functions.ListContains(SnakeMovePositionList, transform.position))
            {
                Functions.EndGame();
            }
        }

        //change direction of snake move && check if in this turn snake doesn't rotate
        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow) && step_counter != diary)
        {
            if (alpha != 90 && alpha != 270)                            //check if snake is not moving on Right or Left side
            {
                diary = step_counter;                                   //save the step when rotation has been taken
                transform.localRotation = Quaternion.Euler(0, 270, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow) && step_counter != diary)
        {
            if (alpha != 270 && alpha != 90)
            {
                diary = step_counter;
                transform.localRotation = Quaternion.Euler(0, 90, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow) && step_counter != diary)
        {
            if (alpha != 0 && alpha != 180)
            {
                diary = step_counter;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow) && step_counter != diary)
        {
            if (alpha != 180 && alpha != 0)
            {
                diary = step_counter;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        alpha = transform.rotation.eulerAngles[1];                      //read the angle of snakes' moving
    }

    public void SnakeGrow()
    {
        SnakeBodySize++;
    }
}
