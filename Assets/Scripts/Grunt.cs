using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour
{
    private float gruntSpeed = 0;
    private float gruntBorder = -10f;
    public float disableColliderBorder = -8.3f;

    public GameObject Player;
    public Rigidbody2D rb;
    private Collider2D coll2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();

        gruntSpeed = UnityEngine.Random.Range(2.5f, 6.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        disableCollider();
        destroyGrunt();
        moveGrunt();
    }

    public void moveGrunt()
    {
        Vector2 movement = new Vector2(-1, 0) * gruntSpeed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    public void destroyGrunt()
    {
        if(rb.position.x < gruntBorder)
        {
            Destroy(gameObject);
        }
    }

    public void disableCollider()
    {
        if(rb.position.x < disableColliderBorder)
        {
            coll2D.enabled = false;
        }
    }


}
