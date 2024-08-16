using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You lose. :(");
        Time.timeScale = 0;
    }
}
