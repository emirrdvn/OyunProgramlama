using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public float speed = 4;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        Movement();
        

    }
    void Movement(){
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -11)
        {
            Respawn();
        }
        
        // if (transform.position.y >= 3)
        // {
        //     transform.position = new Vector3(transform.position.x, -11, 0);
        // }
        // else if (transform.position.y <= -11)
        // {
        //     transform.position = new Vector3(Random.Range(-11,12), 3, 0);
        // }

        // if (transform.position.x >= 12)
        // {
        //     transform.position = new Vector3(-13f, transform.position.y, 0);
        // }
        // else if (transform.position.x <= -13)
        // {
        //     transform.position = new Vector3(12f, transform.position.y, 0);
        // }
    }
    void OnTriggerEnter(Collider other){
        Debug.Log(other.transform.name+" Çarpıştı");
        if(other.tag == "Player"){
            PlayerSC player = other.transform.GetComponent<PlayerSC>();
            player.Damage();
            Debug.Log("Player Health"+ player.health);
            Destroy(this.gameObject);
            
        }
        if(other.tag == "Bullet"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

     void Respawn()
    {
        transform.position = new Vector3(Random.Range(-10, 10), 7, 0);
    }
}
