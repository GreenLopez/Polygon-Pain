

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntSpawner : MonoBehaviour
{

    public float timer = 0.3f;

    public GameObject Player;
    public GameObject gruntPrefab;

    PlayerController playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnGrunt();
    }

    public void spawnGrunt() {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            float spawnRange = UnityEngine.Random.Range(playerScript.bottomBound - 0.2f, playerScript.topBound - 0.4f);

            Instantiate(gruntPrefab, transform.position + new Vector3(0f, spawnRange, 0f), Quaternion.identity);
            Debug.Log("Spawned Grunt - independent");

            timer = 0.3f;
        }
    }
}
