using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YourScoreShow : MonoBehaviour
{
    public TextMeshProUGUI result;
    float timer;

    void Awake()
    {
        timer = Time.time + 2f;
        result.text = "Your Score: " + PointsManager.point;
        PointsManager.point = 0;
    }

    private void Update()
    {
        if (Input.anyKey | Time.time > timer)
        {
            SceneManager.LoadScene(0);
        }
    }
}
