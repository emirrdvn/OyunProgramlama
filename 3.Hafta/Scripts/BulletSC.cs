using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField]
    float mvspeed=10;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*mvspeed*Time.deltaTime);
        if(transform.position.y >=3){
            Destroy(this.gameObject);} 
        else if(transform.position.y <=-11){
            Destroy(this.gameObject);}
        if(transform.position.x >= 12){
            Destroy(this.gameObject);}
        else if(transform.position.x <= -13){
            Destroy(this.gameObject);}
    }
}
