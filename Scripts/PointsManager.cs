using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int point;
    public TextMeshProUGUI pointsOnInterface;

    public void AddPoint()
    {
        point++;
        pointsOnInterface.text = point.ToString();
    }
}
