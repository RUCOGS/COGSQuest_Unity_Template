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

        //If we have collided with an object tagged "Player"
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovementScript>().health -= damage;
        }

        //When the bullet collides with anything, it should disappear.
        Destroy(gameObject);   
    }

}
