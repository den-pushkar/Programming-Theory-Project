using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    public static int playerType;
    public static PlayerSelector Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartPowerPlayer()
    {
        playerType = 1;
        SceneManager.LoadScene(0);
    }

    public void StartSpeedPlayer()
    {
        playerType = 2;
        SceneManager.LoadScene(0);
    }
}
