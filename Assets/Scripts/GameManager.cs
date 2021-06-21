using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject bullets;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] public GameObject powerPlayerPref;
    [SerializeField] private GameObject speedPlayerPref;
    [SerializeField] GameObject speedEnemyPref;
    [SerializeField] GameObject powerEnemyPref;
    Vector3 rotationDir = new Vector3(90, 0, 0);
    Vector3 offset = new Vector3(0, 0, 1);
    public Vector3 startPos = new Vector3(0, 0.55f, -4);
    public static bool isGameOver;
    float randomSec;
    [SerializeField] Text timerText;
    [SerializeField] Text overText;
    float sec;

    void Start()
    {
        isGameOver = false;
        randomSec = 1;
        sec = 30;

        if (PlayerSelector.playerType == 1)
        {
            Instantiate(powerPlayerPref, startPos, powerPlayerPref.transform.rotation);
        } else if (PlayerSelector.playerType == 2)
        {
            Instantiate(speedPlayerPref, startPos, speedPlayerPref.transform.rotation);
        }
        StartCoroutine(EnemySpawn());
        StartCoroutine(SpeedEnemySpawn());
    }

    void Update()
    {
        GameOver();
        Timer();
    }

    public void Bullet()
    {
        Instantiate(bullets, GameObject.FindGameObjectWithTag("PowerPlayer").transform.position + offset, Quaternion.Euler(rotationDir));
    }

    public void GameOver()
    {
        if (isGameOver == true)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            overText.text = "Game Over";
            if (sec < 0.1f)
            {
                overText.text = "You Won!";
            }
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

    IEnumerator EnemySpawn()
    {
        int mapLimit = 9;
        Vector3 randomSpawnPos = new Vector3(Random.Range(-mapLimit, mapLimit), 0.55f, 7);
        yield return new WaitForSeconds(randomSec);
        Instantiate(powerEnemyPref, randomSpawnPos, powerEnemyPref.transform.rotation);
        randomSec = Random.Range(0.5f, 1);
        StartCoroutine(EnemySpawn());
    }

    IEnumerator SpeedEnemySpawn()
    {
        int mapLimit = 9;
        Vector3 randomSpawnPos = new Vector3(Random.Range(-mapLimit, mapLimit), 0.55f, 7);
        yield return new WaitForSeconds(randomSec);
        Instantiate(speedEnemyPref, randomSpawnPos, speedEnemyPref.transform.rotation);
        randomSec = Random.Range(0.5f, 1);
        StartCoroutine(SpeedEnemySpawn());
    }

    void Timer()
    {
        sec -= Time.deltaTime;
        timerText.text = "0:" + ((int)sec).ToString();

        if (sec < 0.01f)
        {
            isGameOver = true;
        }
    }
}
