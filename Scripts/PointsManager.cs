using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static int point;
    public static int topscore;
    
    public static string SendPtsAsString()
    {
        return PlayerPrefs.GetInt("topscore").ToString();
    }

    public static void AddPoint()
    {
        point++;
    }

    public static void SavePoint()
    {
        if (point > PlayerPrefs.GetInt("topscore"))
        {
            PlayerPrefs.SetInt("topscore", point);
            PlayerPrefs.Save();
        }
    }
}
