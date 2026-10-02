using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float jumpSpeed;
    public bool canJump = false;
    public bool lookingRight = true;
    public float topBound = 300.0f;
    public int ammo = 15;

    private SpriteRenderer spriteRend;
    private Rigidbody2D spriteRb;
    private Collider2D playerCollider;
    private Animator playerAnim;
    public AudioSource jumpSound;
    public GameObject coinBulletRight; //Uses gold coin prefab
    public GameObject coinBulletLeft; //Uses gold coin prefab

    //public MoveGoldCoin moveGoldCoinScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //moveGoldCoinScript = GetComponent<MoveGoldCoin>();
        spriteRb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
        playerCollider = GetComponent<Collider2D>();
        //get rigid body component
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            
            //make player jump when space is pressed
            spriteRb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            canJump = false;

            playerAnim.SetBool("isJumping", true);
            jumpSound.Play();
        }

        if (horizontalInput == -1)
        {
            spriteRend.flipX = true;
            lookingRight = false;

            Debug.Log("Looking Left");
        }
        else if(horizontalInput == 1)
        {
            spriteRend.flipX = false;
            lookingRight = true;
        }

        if(horizontalInput != 0)
        {
            playerAnim.SetBool("isRunning", true);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
            //playerAnim.SetBool("isJumping", false);
        }

        ShootGoldCoinRight();
        ShootGoldCoinLeft();
        RespawnPlayer();
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.fixedDeltaTime);

        /*Vector2 targetPos = spriteRb.position + Vector2.right * horizontalInput * speed * Time.deltaTime;
        spriteRb.MovePosition(targetPos);*/
    }

    public void ShootGoldCoinRight()
    {
        if (Input.GetMouseButtonDown(0) && lookingRight == true && ammo > 0)
        {
            Instantiate(coinBulletRight, transform.position, coinBulletRight.transform.rotation);
            ammo--;
            //coinBullet.transform.Translate(coinBullet.transform.right * Time.deltaTime * speed);
        }
    }

    public void ShootGoldCoinLeft()
    {
        if (Input.GetMouseButtonDown(0) && lookingRight == false && ammo > 0)
        {
            Instantiate(coinBulletLeft, transform.position, coinBulletLeft.transform.rotation);
            ammo--;
        }
    }

    public void RespawnPlayer()
    {
        Vector2 playerPosition = transform.position;

        if (playerPosition.y < -topBound)
        {
            transform.position = new Vector2(0, 0);

        }
    }

    public void CollectAmmo(Collider2D playerCollider)
    {
        if(playerCollider.gameObject.CompareTag("Gold Ammo") && ammo < 30)
        {
            ammo++;
            Destroy(playerCollider.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //other.CompareTag("Gold Coin")
        if (other.CompareTag("Gold Coin"))
        {
            Destroy(other.gameObject);
        }

        CollectAmmo(other);

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //other.gameObject.CompareTag("Ground")
        if (other.gameObject.CompareTag("Ground"))
        {
            playerAnim.SetBool("isJumping", false);
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = false;

        }
    }
}
