using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlayer : PlayerController
{

    void Start()
    {
        speed = 3;
    }

    void Update()
    {
        Movement();
        Firing();
        Collided();
    }

    public override void Firing()
    {
        breakTime = breakTime + Time.deltaTime;
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (Input.GetKeyDown(KeyCode.Space) && breakTime > 1)
        {
            gameManagerScript.Bullet();
            breakTime = 0;
        }
    }

}
