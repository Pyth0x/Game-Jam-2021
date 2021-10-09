using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public GameObject[] enemies;
    public float enemySpawnTime = 0.1f;
    int[] spawnPoints = { -2, 0, 2 };
    void Start()
    {
        InvokeRepeating("spawnEnemies", 0, enemySpawnTime);
        InvokeRepeating("spawnEnemies", 0.15f, enemySpawnTime);
    }


    void spawnEnemies()
    {
        int randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
        if(randomEnemy.gameObject.name == "Enemy Capsule")
        {
            Vector3 vector = new Vector3(randomSpawnPoint, transform.position.y+0.5f, transform.position.z);
            Instantiate(randomEnemy, vector, Quaternion.identity);
        }
        else
        {
            Vector3 vector = new Vector3(randomSpawnPoint, transform.position.y, transform.position.z);
            Instantiate(randomEnemy, vector, Quaternion.identity);
        }
    }
}
