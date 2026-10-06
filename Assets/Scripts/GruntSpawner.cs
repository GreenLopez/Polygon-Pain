using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntSpawner : MonoBehaviour
{

    public float timer = 0.3f;
    public int maxGruntsAllowed = 12;
    public int currentNumGrunts = 0;

    public GameObject Player;
    public GameObject gruntPrefab;
    public GameObject EnemyManager;

    PlayerController playerScript;
    Grunt gruntScript;
    EnemyManager enemyManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
        gruntScript = gruntPrefab.GetComponent<Grunt>();
        enemyManagerScript = EnemyManager.GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnGrunt();
        checkNumberOfGrunts();
    }

    public void spawnGrunt() {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            float spawnRange = UnityEngine.Random.Range(playerScript.bottomBound - 0.2f, playerScript.topBound - 0.4f);

            if(currentNumGrunts < maxGruntsAllowed)
            {
                Instantiate(gruntPrefab, transform.position + new Vector3(0f, spawnRange, 0f), Quaternion.identity);
                currentNumGrunts++;
                Debug.Log("Spawned Grunt - independent");
            }
                timer = 0.3f;
        }
    }

    public void checkNumberOfGrunts()
    {
        if (enemyManagerScript.subtractFromCurrentGruntNum == true)
        {
            Debug.Log("SUBTRACTING NUMBER OF GRUNTS");
            currentNumGrunts--;
            enemyManagerScript.subtractFromCurrentGruntNum = false;
        }
    }
}
