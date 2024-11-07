using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerSC : MonoBehaviour
{
    public GameObject enemyPrefab; // Üretilecek düşman prefab'i
    public Transform enemyParent;  // Düşmanların toplanacağı parent nesne
    public GameObject powerUpPrefab; // Üretilecek powerUp prefab'i
    public Transform powerUpParent;  // PowerUp'ların toplanacağı parent nesne
    public float spawnInterval = 5f; // Spawn aralığı
    public float spawnIntervalPowerUp = 15f; // PowerUp spawn aralığı
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
        // PowerUp'ı oluştur ve parent nesnesinin altına yerleştir
        GameObject newPowerUp = Instantiate(powerUpPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        newPowerUp.transform.parent = powerUpParent;
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
