using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//140 bpm
[System.Serializable]
public class Enemy{

    public string name; 

    public GameObject prefab;
    [Range(0f, 100f)] public float chance = 100f;
    [HideInInspector] public float _weight;

}

public class SpawnPointScript : MonoBehaviour
{

    [SerializeField] private Enemy[] enemies;
    public float enemySpawnTime = 0.002f;
    
    System.Random rand = new System.Random();
    int[] spawnPoints = { -3, 0, 3 };
    float accumulatedWeights;

    private void Awake()
    {
        CalculateWeights();
    }

    void Start()
   {
       InvokeRepeating("spawnEnemies", 0, enemySpawnTime);
   }


   void spawnEnemies()
   {
        int randomSpawnPoint = spawnPoints[GetRandomEnemyIndex()];
        Enemy randomEnemy = enemies[GetRandomEnemyIndex()];
        Debug.Log(randomEnemy.name + randomEnemy.chance);


        if (randomEnemy.prefab.name == "Enemy Capsule")
       {
           Vector3 vector = new Vector3(randomSpawnPoint, transform.position.y+0.5f, transform.position.z);
           Instantiate(randomEnemy.prefab, vector, Quaternion.identity);
       }
       else
       {
           Vector3 vector = new Vector3(randomSpawnPoint, transform.position.y, transform.position.z);
           Instantiate(randomEnemy.prefab, vector, Quaternion.identity);
       }

    }

    int GetRandomEnemyIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for (int i = 0; i < enemies.Length-1; i++)
            if (enemies[i]._weight >= r)
                return i;

        return 0;
    }

    void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach(Enemy enemy in enemies)
        {
            accumulatedWeights += enemy.chance;
            enemy._weight = accumulatedWeights;
        }
    }
}