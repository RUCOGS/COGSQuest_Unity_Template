using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{


    //<---SECTION A: CLASS VARIABLES--->

    //Variables at the top of the class are called "static variables" or "class variables"
    //for this template, we will be calling them class variables.
    //let's go over what class variables we have!


    //This variable stores a reference to our player object.
    //This is so that our enemy can find the player and then follow it.
    public GameObject player;


    //This variable will hold the speed of our enemy movement.
    public float speed;




    //<---SECTION B: THE START FUNCTION--->


    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to our player, store it in our player variable.
        player = GameObject.FindGameObjectWithTag("Player");
    }




    //<---SECTION C: THE UPDATE FUNCTION-->


    // Update is called once per frame
    void Update()
    {

        //We are using a built-in function called Vector3.MoveTowards.
        //Every frame, move the enemy towards the player's current position by "speed"
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }




    //<---SECTION D: ONCOLLISIONENTER2D FUNCTION--->

    //This function is built into Unity. It detects whether the object has entered a collision.
    //This function only runs ONCE on collision.
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //This if-statement will evaluate the tag of the object that we are colliding with.
        //The tag must be "Player" for the if-statement to run. CAPITALIZATION MATTERS!!!!
        if (collision.gameObject.tag == "Player")
        {



            //Reduce the player's health by 1.
            //You will need to get the PlayerMovementScript component from the GameObject that you are colliding with.
            //From here, you can access the "health" variable.
            collision.gameObject.GetComponent<PlayerMovementScript>().health -= 1;



            //If an enemy hits the player, the enemy will destroy itself.
            //Destroy the object that this script is attached to.
            Destroy(gameObject);




        }
    }
}
