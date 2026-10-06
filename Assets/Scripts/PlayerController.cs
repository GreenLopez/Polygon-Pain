using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xPos = -8.0f;
    public float playerSpeed = 5;
    public float verticalInput;
    public float topBound = 5.0f;
    public float bottomBound = -5.0f;
    public int magazine = 2;
    public float timer;
    public bool canShoot = true;
    public bool didShoot = false;

    public GameObject bulletPrefab;
    public GameObject gruntPrefab;
    public Vector2 playerPosition;
    private Rigidbody2D rb;
    public AudioSource shootSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 144;

        shootSound = GetComponent<AudioSource>();

        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        teleportPlayer();

        checkMagazine();

    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    public void spawnBullet()
    {
        Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.identity);
        SoundFXManager.instance.playAudioFXClip(shootSound.clip, transform, 0.5f);
    }

    public void checkMagazine()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow) && canShoot == true)
        {

            spawnBullet();
            magazine--;

            if(magazine <= 0)
            {
                canShoot = false;
            }

            didShoot = true;
        }

        if(didShoot == true)
        {
            timer -= Time.deltaTime;
        }

        reloadMagazine();

    }

    public void reloadMagazine()
    {
        if(timer <= 0)
        {
            magazine = 3;
            timer = 1f;
            canShoot = true;
            didShoot = false;
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
