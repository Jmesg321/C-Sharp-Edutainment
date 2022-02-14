using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] Enemy;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;




    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAnEnemy", 0f, 8f);

    }

    void SpawnAnEnemy()
    {
        if (spawnAllowed) {
            randomSpawnPoint = Random.Range(0,spawnPoints.Length);
            randomEnemy = Random.Range(0, Enemy.Length);
            Instantiate(Enemy[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        
        }
    }

  
}
