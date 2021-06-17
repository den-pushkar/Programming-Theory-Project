using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
    [SerializeField] private GameObject gameOverScreen;
    Vector3 offset = new Vector3(90, 0, 0);
    public static bool isGameOver;


    void Start()
    {
        isGameOver = false;
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
        isGameOver = false;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
