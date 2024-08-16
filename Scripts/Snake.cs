using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public int SnakeBodySize;
    public List<Vector3> SnakeMovePositionList;

    int interval = 1;
    float nextTime = 0;
    int diary = 0;

    float alpha = 0;                                                    //angle; direction of snake moving

    void Update()
    {
        if (Time.time >= nextTime)                                      //"1px step per 1sec" logic
        {
            SnakeMovePositionList.Insert(0, transform.position);        //add snakes' coordinates on 1st position of the list

            if (SnakeMovePositionList.Count >= SnakeBodySize + 1)       //if snake does not grown in this turn, coordinates are remove immediately
            {
                SnakeMovePositionList.RemoveAt(SnakeMovePositionList.Count - 1);
            }

            for (int i = 0; i < SnakeMovePositionList.Count; i++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.GetComponent<BoxCollider>().enabled = false;
                cube.transform.localPosition = SnakeMovePositionList[i];
                GameObject.Destroy(cube, interval);
            }

            transform.position += transform.forward;
            nextTime += interval;

            Debug.Log("nextTime: " + nextTime);
            Debug.Log("diary: " + diary);

        }

        if (Input.GetKeyDown(KeyCode.A) && (int)Time.time != diary)     //change direction of snake move && check if in this turn snake doesn't rotate
        {
            if (alpha != 90 && alpha != 270)                            //check if snake is not moving on Right or Left side
            {
                diary = (int)Time.time;                                 //save the time[sec] of rotation
                transform.localRotation = Quaternion.Euler(0, 270, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && (int)Time.time != diary)
        {
            if (alpha != 270 && alpha != 90)
            {
                diary = (int)Time.time;
                transform.localRotation = Quaternion.Euler(0, 90, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && (int)Time.time != diary)
        {
            if (alpha != 0 && alpha != 180)
            {
                diary = (int)Time.time;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && (int)Time.time != diary)
        {
            if (alpha != 180 && alpha != 0)
            {
                diary = (int)Time.time;
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