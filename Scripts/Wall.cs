using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public TextMeshProUGUI Lose_PopUp;

    private void OnTriggerEnter(Collider other)
    {
        //Functions.EndGame();
        Lose_PopUp.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
