using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{

    public GameObject[] balloonPrefabs;
    public float startDelay = 0.5f;
    public float spawnInterval = 1.5f;

    public float xRange = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBalloon", startDelay, spawnInterval);
    }

    void SpawnRandomBalloon()
    {
        Vector3 spawnPosX = new Vector3(Random.Range(-xRange,xRange), 0, 0);

        int balloonIndex = Random.Range(0, balloonPrefabs.Length);

        Instantiate(balloonPrefabs[balloonIndex], spawnPosX, balloonPrefabs[balloonIndex].transform.rotation);
    }
}
