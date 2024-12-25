using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSC : MonoBehaviour
{

    AudioSource explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        explosionSound = GetComponent<AudioSource>();
        explosionSound.Play();
        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
