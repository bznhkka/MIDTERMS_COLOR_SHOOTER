using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private Vector3 lastMousePosition;
    public float spawnInterval = 10f; // Time interval between spawns in seconds
    private float timeSinceLastSpawn;


    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0f; // Initialize the time since the last spawn
    }

    // Update is called once per frame
    void Update()
    {
        // Update the time since the last spawn
        timeSinceLastSpawn += Time.deltaTime;

        // If enough time has passed since the last spawn, spawn a new enemy
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();

            // Reset the time since the last spawn
            timeSinceLastSpawn = 0f;
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //    int randEnemy = Random.Range(0, enemyPrefabs.Length);
        //    int randSpawPoint = Random.Range(0, spawnPoints.Length);

        //     Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawPoint].position, transform.rotation);
        // }
    }

    void SpawnEnemy()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        // Instantiate the enemy at the random spawn point with no rotation
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);
    }
}
