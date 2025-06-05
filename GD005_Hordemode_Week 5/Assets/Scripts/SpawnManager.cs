using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public int waveNumber;
    int enemyCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);

       
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType <EnemyController> (FindObjectsSortMode.None).Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    Vector3 randomSpawnPosition(float yPosition)
    {
        float randomXPosition = Random.Range(-20, 20);
        float randomZPosition = Random.Range(-30, 30);

        Vector3 spawnPosition = new Vector3(randomXPosition, yPosition, randomZPosition);
        return spawnPosition;
    }

   void SpawnPowerUp()
    {
      
    }

    void SpawnEnemyWave (int enemiestoSpawn)
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], randomSpawnPosition(0), Quaternion.identity);
        }
    }
}


