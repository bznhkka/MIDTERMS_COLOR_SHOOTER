using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public PlayerBehavior playerBehavior;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 5.0f; // Time interval between spawns in seconds

    private float secondsSinceLastSpawn;


    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastSpawn = 0.0f; // Initialize the time since the last spawn
    }


    void FixedUpdate()
    {
        Assert.IsNotNull(playerBehavior);

        // Update the time since the last spawn
        secondsSinceLastSpawn += Time.deltaTime;

        // If enough time has passed since the last spawn, spawn a new enemy
        if (secondsSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();

            // Reset the time since the last spawn
            secondsSinceLastSpawn = 0f;
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
        GameObject instantiatedEnemy = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);
        EnemyBehavior enemyBehavior = instantiatedEnemy.GetComponent<EnemyBehavior>();
        enemyBehavior.speed = 10.0f;
        enemyBehavior.playerTransform = playerBehavior.transform;

        // Add reference
        playerBehavior.AddEnemy(ref instantiatedEnemy);
    }
}
