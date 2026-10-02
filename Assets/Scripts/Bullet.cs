using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 7;
    public float bulletBoundary = 30;

    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    private void FixedUpdate()
    {
        /*Vector2 movement = new Vector2(1, 0) * bulletSpeed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);*/

        

        destroyBullet();
    }

    public void destroyBullet()
    {
        if(rb.position.x > bulletBoundary)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);


        }

    }

}
