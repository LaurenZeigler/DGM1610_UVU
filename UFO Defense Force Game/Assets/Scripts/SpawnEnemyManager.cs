using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    [SerializeField]
    private float spawnRangeX = 11.0f;
    [SerializeField]
    private float spawnPosZ;

    private float startDelay = 2f;
    private float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnRandomEnemy()
    {
        // generate a pos to spawn at
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // pick a random enemy to spawn from array
        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        //spawn the enemy indexed from array
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
