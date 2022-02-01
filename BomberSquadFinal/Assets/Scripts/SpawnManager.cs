using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject[] powerups;
    private float spawnRange = 13;

    public int enemyCount;
    public int wavesNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PowerupSpawner",1,4);
        SpawnWaves(wavesNumber);
    }


    void SpawnWaves(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyMovement>().Length;
        if (enemyCount == 0)
        {
            //  Debug.Log("hussain");     
            wavesNumber++;
            SpawnWaves(wavesNumber);
       
        }
    }
    void PowerupSpawner()
    {
        int index = Random.Range(0, powerups.Length);
        Instantiate(powerups[index], GenerateRandomPosition(), powerups[index].transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomRange = new Vector3(spawnPosX, 1.3f, spawnPosZ);

        return randomRange;
    }
}
