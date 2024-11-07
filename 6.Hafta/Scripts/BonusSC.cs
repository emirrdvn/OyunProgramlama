using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSC : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.transform.name + " Çarpıştı");
        if (other.tag == "Player")
        {
            PlayerSC player = other.transform.GetComponent<PlayerSC>();
            player.TripleShotActiveMethod();

            Destroy(this.gameObject);

        }
        if (other.tag == "Bullet")
        {
            Debug.Log("Bullet Bonus ile Çarpıştı");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    float mvspeed = 5;
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * mvspeed * Time.deltaTime);
        if (transform.position.y >= 3)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.y <= -11)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x >= 12)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.x <= -13)
        {
            Destroy(this.gameObject);
        }
    }
}