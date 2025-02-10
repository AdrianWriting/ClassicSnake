using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Apple : MonoBehaviour
{
    public Snake snake;

    private void Start()
    {
        if (snake == null) 
            snake = FindObjectOfType<Snake>();
    }
    public void OnTriggerEnter(Collider other)
    {
        PointsManager.AddPoint();
        snake.SnakeGrow();
        int last_pos_x = Convert.ToInt32(transform.position.x);     //save info about last position, which hasn't been stored in SnakeMovePositionList (gap)
        int last_pos_z = Convert.ToInt32(transform.position.z);
        do
        {
            transform.position = new Vector3(UnityEngine.Random.Range(-9, 11), 0, UnityEngine.Random.Range(-5, 6));
        } while ((last_pos_x == transform.position.x && last_pos_z == transform.position.z) || Functions.ListContains(snake.SnakeMovePositionList, transform.position));
    }
}
