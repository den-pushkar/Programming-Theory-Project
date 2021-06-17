using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] public GameObject powerPlayerPref;
    [SerializeField] private GameObject speedPlayerPref;
    Vector3 offset = new Vector3(90, 0, 0);
    public Vector3 startPos = new Vector3(0, 0.55f, -4);
    public static bool isGameOver;

    void Start()
    {
        isGameOver = false;

        if (PlayerSelector.playerType == 1)
        {
            Instantiate(powerPlayerPref, startPos, powerPlayerPref.transform.rotation);
        } else if (PlayerSelector.playerType == 2)
        {
            Instantiate(speedPlayerPref, startPos, speedPlayerPref.transform.rotation);
        }
    }

    void Update()
    {
        GameOver();
    }

    public void Bullet()
    {
        Instantiate(bullets, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.Euler(offset));
    }

    public void GameOver()
    {
        if (isGameOver == true)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

public void Restart()
    {
        Destroy(GameObject.Find("PlayerSelector"));
        isGameOver = false;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
