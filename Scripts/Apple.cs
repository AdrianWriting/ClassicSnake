using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Apple : MonoBehaviour
{
    public PointsManager pointsManager;
    public Snake snake;

    private void Start()
    {
        if (pointsManager == null) 
            pointsManager = FindObjectOfType<PointsManager>();

        if (snake == null) 
            snake = FindObjectOfType<Snake>();
    }
    public void OnTriggerEnter(Collider other)
    {
        pointsManager.AddPoint();
        snake.SnakeGrow();
        int last_pos_x = Convert.ToInt32(transform.position.x);
        int last_pos_z = Convert.ToInt32(transform.position.z);
        do
        {
            transform.position = new Vector3(UnityEngine.Random.Range(-7, 7), 0, UnityEngine.Random.Range(-5, 5));
        } while ((last_pos_x == transform.position.x && last_pos_z == transform.position.z) || ListContains(snake.SnakeMovePositionList, transform.position));
    }

    private bool ListContains(List<Vector3> hist_list, Vector3 new_pos)
    {
        int new_pos_x = Convert.ToInt32(new_pos.x);
        int new_pos_z = Convert.ToInt32(new_pos.z);
        for (int i = 0; i < hist_list.Count; i++)
        {
            int hist_list_x = Convert.ToInt32(hist_list[i].x);
            int hist_list_z = Convert.ToInt32(hist_list[i].z);
            if (hist_list_x == new_pos_x && hist_list_z == new_pos_z)
            {
                return true;
            }
        }
        return false;
    }
}
