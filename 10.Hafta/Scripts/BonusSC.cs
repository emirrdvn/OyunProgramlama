using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSC : MonoBehaviour
{
    AudioSource bonusSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.transform.name + " Çarpıştı");
        if (other.tag == "Player")
        {
            PlayerSC player = other.transform.GetComponent<PlayerSC>();
            switch (transform.name)
            {
                case "TripleShotPowerUp(Clone)":
                    player.TripleShotActiveMethod();
                    break;
                case "SpeedPowerUp(Clone)":
                    player.SpeedBoostActiveMethod();
                    break;
                default:
                    break;
            }
            
            bonusSound.Play();
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
        bonusSound = GameObject.Find("BonusSound").GetComponent<AudioSource>();
    }
    float mvspeed = 5;
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * mvspeed * Time.deltaTime);
       /**/
    }
}
