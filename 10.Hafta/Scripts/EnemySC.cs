using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySC : MonoBehaviour
{
    [SerializeField]
    GameObject ExplosionAnimation;
    PlayerSC playerScoreCont;
    // Start is called before the first frame update
    void Start()
    {
        playerScoreCont = GameObject.Find("Player").GetComponent<PlayerSC>();
        if (playerScoreCont == null)
        {
            Debug.LogError("PlayerSC script not found");
        }
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
        
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.transform.name+" Çarpıştı");
        if(other.tag == "Player"){
            speed = 0;
            PlayerSC player = other.transform.GetComponent<PlayerSC>();
            player.Damage();
            Debug.Log("Player Health"+ player.health);
            Destroy(this.gameObject);
            
            
        }
        if(other.tag == "Bullet"){
            speed = 0;
            Destroy(other.gameObject);
            if(playerScoreCont != null){
                playerScoreCont.ScoreUp(10);
            }
            Destroy(this.gameObject);
        }
        Instantiate(ExplosionAnimation, transform.position, Quaternion.identity);
    }

     void Respawn()
    {
        transform.position = new Vector3(Random.Range(-10, 10), 7, 0);
    }
}
