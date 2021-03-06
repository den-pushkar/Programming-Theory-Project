using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public static GameManager gameManagerScript;
    public float speed = 15;
    public float breakTime = 0;
    public static bool isCollieded;

    void Start()
    {
        isCollieded = false;   
    }

    public virtual void Movement()
    {
        playerRb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.AddForce(Vector3.left * speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.AddForce(Vector3.right * speed);
        }
        //bounds
        if (transform.position.x > 9.2f)
        {
            playerRb.velocity = Vector3.zero;
        } else if (transform.position.x < -9.2f)
        {
            playerRb.velocity = Vector3.zero;
        }
    }

    public virtual void Firing()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (Input.GetKeyDown(KeyCode.Space) && breakTime > 1)
        {
            gameManagerScript.Bullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
            isCollieded = true;
            }
        }

    public virtual void Collided()
    {
        if (isCollieded)
        {
            isCollieded = false;
            GameManager.isGameOver = true;
        }
    }
}


