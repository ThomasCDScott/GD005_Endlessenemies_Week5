using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], randomSpawnPosition(0), Quaternion.identity);
        }
    }

    Vector3 randomSpawnPosition(float yPosition)
    {
        float randomXPosition = Random.Range(-20, 20);
        float randomZPosition = Random.Range(-30, 30);

        Vector3 spawnPosition = new Vector3(randomXPosition, yPosition, randomZPosition);
        return spawnPosition;
    }

    public void damage(int damageDealt)
    {
        //health -= damageDealt;
    }
   
}


