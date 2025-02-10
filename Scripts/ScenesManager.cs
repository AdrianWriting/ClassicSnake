using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScenesManager : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void StartGame()
    {
        Snake.GameOn = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
