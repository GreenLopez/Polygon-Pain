using UnityEngine;

public class Grunt : MonoBehaviour
{
    private float gruntSpeed = 0;
    private float gruntBorder = -10f;
    public float disableColliderBorder = -8.3f;

    public GameObject Player;
    public EnemyManager EnemyManager;
    
    public AudioSource gruntDestroyedSound;

    public Rigidbody2D rb;
    private Collider2D coll2D;

    PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();

        EnemyManager = FindAnyObjectByType<EnemyManager>();

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
        if (rb.position.x < gruntBorder)
        {
            EnemyManager.subtractFromCurrentGruntNum = true;
            Destroy(gameObject);
            
        }
    }

    public void disableCollider()
    {
        if (rb.position.x < disableColliderBorder)
        {
            coll2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            SoundFXManager.instance.playAudioFXClip(gruntDestroyedSound.clip, transform, 0.3f);
            EnemyManager.subtractFromCurrentGruntNum = true;

            print("GRUNT DESTROYED");

            Destroy(gameObject);
        }
    }
}
