using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerSC : MonoBehaviour
{
    public GameObject enemyPrefab; // Üretilecek düşman prefab'i
    public Transform enemyParent;  // Düşmanların toplanacağı parent nesne
    public float spawnInterval = 5f; // Spawn aralığı
    private bool spawnActive = true; // Spawn işlemini durdurmak için kullanılacak

    void Start()
    {
        StartCoroutine(SpawnEnemies()); // Coroutine başlatılıyor
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
