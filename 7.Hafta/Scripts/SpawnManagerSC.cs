using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerSC : MonoBehaviour
{
    public GameObject enemyPrefab; // Üretilecek düşman prefab'i
    public Transform enemyParent;  // Düşmanların toplanacağı parent nesne
    public GameObject TripleShotPowerUpPrefab; // Üretilecek powerUp prefab'i
    public GameObject SpeedPowerUpPrefab; // Üretilecek powerUp prefab'i
    public GameObject ShieldPowerUpPrefab; // Üretilecek powerUp prefab'i
    public Transform powerUpParent;  // PowerUp'ların toplanacağı parent nesne
    public float spawnInterval = 5f; // Spawn aralığı
    public float spawnIntervalPowerUp = 4f; // PowerUp spawn aralığı
    private bool spawnActive = true; // Spawn işlemini durdurmak için kullanılacak

    void Start()
    {
        StartCoroutine(SpawnEnemies()); // Coroutine başlatılıyor
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnPowerUps()
    {
        // PowerUp'ları her spawnInterval sürede bir üretiyor
        while (spawnActive)
        {
            SpawnPowerUp();
            yield return new WaitForSeconds(spawnIntervalPowerUp);
        }
    }
    void SpawnPowerUp()
    {
        int randomPowerUp = Random.Range(0, 4);
        if (randomPowerUp == 1)
        {
            GameObject newPowerUp = Instantiate(TripleShotPowerUpPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            newPowerUp.transform.parent = powerUpParent;
        }
        else if (randomPowerUp == 2)
        {
            GameObject newPowerUp = Instantiate(ShieldPowerUpPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            newPowerUp.transform.parent = powerUpParent;
        }
        else
        {
            GameObject newPowerUp = Instantiate(SpeedPowerUpPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            newPowerUp.transform.parent = powerUpParent;
        }
        // PowerUp'ı oluştur ve parent nesnesinin altına yerleştir
        
        
    }
    IEnumerator SpawnEnemies()
    {
        // Düşmanları her spawnInterval sürede bir üretiyor
        while (spawnActive)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }


    void SpawnEnemy()
    {
        // Düşmanı oluştur ve parent nesnesinin altına yerleştir
        GameObject newEnemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        newEnemy.transform.parent = enemyParent;
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Düşmanın üretileceği rastgele bir pozisyon belirleyin (örnek)
        float xPos = Random.Range(-10f, 10f);
        float zPos = Random.Range(-10f, 10f);
        return new Vector3(xPos, 0, zPos);
    }

    public void StopSpawning()
    {
        spawnActive = false;
    }
}
