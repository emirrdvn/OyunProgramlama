using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AstroidSC : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _rotateSpeed = 20.0f;
    [SerializeField]
    GameObject ExplosionAnimation;
    [SerializeField]
    SpawnManagerSC _spawnManager;
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManagerSC>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            PlayerSC player = other.transform.GetComponent<PlayerSC>();
            if(player != null){
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        if(other.tag == "Bullet"){
            _spawnManager.StartSpawning();
            Destroy(other.gameObject);
            Instantiate(ExplosionAnimation, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
