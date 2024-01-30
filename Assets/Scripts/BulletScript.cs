using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Vector3 bulletSpeed;
    public int damage;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Every frame, the bullet is traveling at the speed we set.
        transform.position += bulletSpeed;
    }


    //This function is built into Unity. It detects whether the object has entered a collision.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding with " +collision.gameObject.name);

        //This if-statement will evaluate the tag of the object that we are colliding with.
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy the object that our bullet is COLLIDING with.
            Destroy(collision.gameObject);
            
        }
        
        //When the bullet collides with anything, it should disappear.
        Destroy(gameObject);
        

        
         
    }

}
