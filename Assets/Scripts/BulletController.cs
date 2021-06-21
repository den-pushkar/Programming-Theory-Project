using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int bound = 10;
    private float speed = 10;
    bool isUp;

    void Start()
    {
        if (transform.position.z > -4)
        {
            isUp = true;
        } else if (transform.position.z < -4)
        {
            isUp = false;
        }
    }

    void Update()
    {
        LaunchDirection();
        OutOfBounds();
    }

    void LaunchDirection()
    {
        if (isUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (!isUp)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    void OutOfBounds()
    {
        if (transform.position.z > bound || transform.position.z < -bound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.isGameOver = true;
        } else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
