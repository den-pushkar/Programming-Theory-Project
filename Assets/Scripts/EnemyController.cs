using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody enemyRb;
    public float enemySpeed;

    private int bound = 10;


    public void Movement()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.AddForce(Vector3.back * enemySpeed);
    }

    public void OutOfBounds()
    {
        if (transform.position.z > bound || transform.position.z < -bound)
        {
            Destroy(gameObject);
        }
    }

}
