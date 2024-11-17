using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using TMPro;
using UnityEngine;

public class Functions : MonoBehaviour
{
    public static bool ListContains(List<Vector3> hist_list, Vector3 new_pos)
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
