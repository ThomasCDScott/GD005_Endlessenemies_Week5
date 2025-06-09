using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public int waveNumber;
    int enemyCount;
    public GameObject[] powerup;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);

        Instantiate(powerup[Random.Range(0, powerup.Length)], randomSpawnPosition(0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }

        if (enemyCount == 0)
        {
            Instantiate(powerup[Random.Range(0, powerup.Length)], randomSpawnPosition(0), Quaternion.identity);
        }
    }

    Vector3 randomSpawnPosition(float yPosition)
    {
        float randomXPosition = Random.Range(-20, 20);
        float randomZPosition = Random.Range(-30, 30);

        Vector3 spawnPosition = new Vector3(randomXPosition, yPosition, randomZPosition);
        return spawnPosition;
    }


    void SpawnEnemyWave (int enemiestoSpawn)
    {
        for (int i = 0; i < enemiestoSpawn; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], randomSpawnPosition(0), Quaternion.identity);
        }

        waveNumber++;
    }
}


