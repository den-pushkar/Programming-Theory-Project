using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlayer : PlayerController 
{

    void Start()
    {
        speed = 15;
    }

    void Update()
    {
        Movement();
        Collided();
    }

    public override void Collided()
    {
        if (isCollieded)
        {
            StartCoroutine(SpeedBoost());
            isCollieded = false;
        }
    }

    IEnumerator SpeedBoost()
    {
        speed *= 2;
        yield return new WaitForSeconds(3);
        speed /= 2;
    }

}
