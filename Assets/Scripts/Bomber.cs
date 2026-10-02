using UnityEngine;

public class Bomber : MonoBehaviour
{

    public float bombmerSpeed = 3f;
    public float bomberRotateSpeed = 2f;

    public GameObject Player;
    public Rigidbody2D rb;

    PlayerController playerScript;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 direction = ((Vector2)Player.transform.position - rb.position).normalized;
        //Vector2 movement = new Vector2(-1, 0) * bombmerSpeed;

        //Figure out how to rotate Bomber

        rb.linearVelocity = direction * bombmerSpeed;
    }

    public void moveBomber()
    {

    }

    public void targetPlayer()
    {

    }
}
