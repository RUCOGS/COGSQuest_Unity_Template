using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    //<---SECTION A: CLASS VARIABLES--->

    //Variables at the top of the class are called "static variables" or "class variables"
    //for this template, we will be calling them class variables.
    //let's go over what class variables we have!

    public Vector3 bulletSpeed;
    public int damage;


    //We don't need Start() in this script, so let's skip that.


    //<---SECTION B: THE UPDATE FUNCTION--->

    // Update is called once per frame
    void Update()
    {

        //Move the bullet's position by bulletSpeed every frame.
        transform.position += bulletSpeed;
    }



    //<---SECTION C: ONCOLLISIONENTER2D FUNCTION--->


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
        
        //Destroy our bullet object, AKA the object that this script is attached to.
        //When the bullet hits anything, it disappears.
        Destroy(gameObject);
        

        
         
    }

}
