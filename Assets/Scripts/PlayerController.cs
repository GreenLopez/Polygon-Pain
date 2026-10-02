using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xPos = -8.0f;
    public float playerSpeed = 5;
    public float verticalInput;
    public float topBound = 5.0f;
    public float bottomBound = -5.0f;

    public GameObject bulletPrefab;
    //public GameObject gruntPrefab;
    public Vector2 playerPosition;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    void Update()
    {

        teleportPlayer();

        spawnBullet();

    }

    private void FixedUpdate()
    {

        

        movePlayer();
    }

    public void spawnBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.identity);
        }
    }

    public void teleportPlayer()
    {
        if (rb.position.y < bottomBound)
        {
            rb.position = new Vector2(xPos, topBound);
        }
        else if (rb.position.y > topBound)
        {
            rb.position = new Vector2(xPos, bottomBound);
        }
    }

    public void movePlayer()
    {
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }
        else
        {
            verticalInput = 0f;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * playerSpeed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
