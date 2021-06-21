using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEnemy : EnemyController
{
    [SerializeField] private GameObject bullets;
    Vector3 rotationDir = new Vector3(-90, 0, 0);
    Vector3 offset = new Vector3(0, 0, -1);
    float randomSec;

    void Start()
    {
        randomSec = Random.Range(0.3f, 1);
        enemySpeed = 3;
        StartCoroutine(RandomSec());
    }


    void Update()
    {
        Movement();
        OutOfBounds();
    }


    IEnumerator RandomSec()
    {
        yield return new WaitForSeconds(randomSec);
        if (transform.position.z > -4.5f)
        {
            Instantiate(bullets, transform.position + offset, Quaternion.Euler(rotationDir));
        }
        randomSec = Random.Range(0.5f, 1);
        StartCoroutine(RandomSec());
    }
}
