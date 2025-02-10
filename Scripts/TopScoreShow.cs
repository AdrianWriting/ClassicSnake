using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopScoreShow : MonoBehaviour
{
    private string topscore;
    public TextMeshProUGUI result;

    void Start()
    {
        topscore = PointsManager.SendPtsAsString();
        result.text = "Top Score: " + topscore;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(0);
        }
    }
}
