using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Spawn_prove : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawnPosition;
    public int waveCount;
    public int wave;
    public bool spawning;
    public int enemyTipe;
    public int enemiesSpawned;
   



    // Start is called before the first frame update
    void Start()
    {
        waveCount = 1;
        wave = 1;
        spawning = false;
        enemiesSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning == false && enemiesSpawned == 0 && waveCount < 200)
        {
            StartCoroutine(SpawnWave(waveCount));
        }
    }

    /*private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range (-spawnRange, spawnRange);
        float spawnPosZ = Random.Range (-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3 (spawnPosX, 5, spawnPosZ);

        return randomPos;
    }*/

    IEnumerator SpawnWave(int waveC)
    {
        spawning = true;

        yield return new WaitForSeconds(4);


        for (int i = 0; i < waveC; i++)
        {
            SpawnEnemy(wave);
        }
        yield return new WaitForSeconds(6);
        enemiesSpawned--;
        wave += 1;
        waveCount += 1;
        spawning = false;

        yield break;
        
    }

    void SpawnEnemy(int wave)
    {
        int spawnPos = Random.Range(0, 6);
        if (wave == 1)
        {
            enemyTipe = Random.Range(0, 1);
        }

        Instantiate(enemyPrefab/*[enemyTipe]*/, spawnPosition[spawnPos].transform.position, spawnPosition[spawnPos].transform.rotation);
        enemiesSpawned +=1;
    }
}
