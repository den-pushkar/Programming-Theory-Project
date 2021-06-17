using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 10;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        OutOfBounds();
    }

    void OutOfBounds()
    {
        if (transform.position.z > 10)
        {
            Destroy(gameObject);
        }
    }
}
