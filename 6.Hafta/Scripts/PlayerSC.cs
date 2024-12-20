using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSC : MonoBehaviour
{
    
    bool TripleShotActive = false;
    private SpawnManagerSC spawnManager;
    // Start is called before the first frame update
    [SerializeField]
    public float speed = 10;
    public float horizontal;
    public float vertical;
    [SerializeField]
    GameObject bulletPreFab;
    [SerializeField]
    float fireRate = 0.5f; // Ateş etme hızı
    private float nextFireTime = 0f; // Bir sonraki atış zamanı

    [SerializeField]
    public int health = 3;
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManagerSC>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        transform.Translate(direction * Time.deltaTime * speed);

        if (transform.position.y >= 3)
        {
            transform.position = new Vector3(transform.position.x, -11, 0);
        }
        else if (transform.position.y <= -11)
        {
            transform.position = new Vector3(transform.position.x, 3, 0);
        }

        if (transform.position.x >= 12)
        {
            transform.position = new Vector3(-13f, transform.position.y, 0);
        }
        else if (transform.position.x <= -13)
        {
            transform.position = new Vector3(12f, transform.position.y, 0);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime) // Zaman kontrolü
        {
            if (TripleShotActive)
            {
                Instantiate(bulletPreFab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                Instantiate(bulletPreFab, transform.position + new Vector3(0.8f, 0.1f, 0), Quaternion.identity);
                Instantiate(bulletPreFab, transform.position + new Vector3(-0.8f, 0.1f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(bulletPreFab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            // Instantiate(bulletPreFab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            nextFireTime = Time.time + fireRate; // Bir sonraki atış zamanını ayarla

        }
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            Debug.Log("Oyuncu öldü!");
            spawnManager.StopSpawning(); // Spawn işlemi durduruluyor
            Destroy(gameObject); // Oyuncu yok ediliyor
        }
    }

    public void TripleShotActiveMethod()
    {
        TripleShotActive = true;
        // 5 saniye sonra TripleShotActive'i false yap
        StartCoroutine(TripleShotPowerDownRoutine());



    }
    //Coroutine
    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        TripleShotActive = false;
    }
}
