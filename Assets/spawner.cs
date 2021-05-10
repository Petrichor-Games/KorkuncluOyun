using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] soul;
    int randomSpawnPoint, randomsoul;
    public static bool spawnAllowed;

    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnSoul", 0f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnSoul()
    {
        if(spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomsoul = Random.Range(0, soul.Length);
            Instantiate(soul[randomsoul], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
            spawnAllowed = false;
        }
    }
}
