using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//140 bpm
[System.Serializable]
public class Enemy1{


    public GameObject prefab;
    [Range(0f, 100f)] public float chance = 100f;
    [HideInInspector] public float _weight;

}

public class SpawnPointScript1 : MonoBehaviour
{

    [SerializeField] private Enemy1[] enemies;
    public float enemySpawnTime = 0.002f;
    
    System.Random rand = new System.Random();
    int[] spawnPoints = { -5, 0, 5 };
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
        int randomSpawnPoint = spawnPoints[Random.Range(0, 3)];
        Enemy1 randomEnemy = enemies[GetRandomEnemyIndex()];
        Vector3 vector = new Vector3(randomSpawnPoint, transform.position.y, transform.position.z);
        Instantiate(randomEnemy.prefab, vector, Quaternion.identity);

    }

    int GetRandomEnemyIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for (int i = 0; i < enemies.Length; i++)
            if (enemies[i]._weight >= r)
                return i;

        return 0;
    }


    void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach(Enemy1 enemy in enemies)
        {
            accumulatedWeights += enemy.chance;
            enemy._weight = accumulatedWeights;
        }
    }
}