using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : EnemyController
{

    void Start()
    {
        enemySpeed = 10;
    }

    void Update()
    {
        Movement();
        OutOfBounds();
    }
}
