using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{


    //<---SECTION A: CLASS VARIABLES--->

    //Variables at the top of the class are called "static variables" or "class variables"
    //for this template, we will be calling them class variables.
    //let's go over what class variables we have!


    public GameObject player;
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovementScript>().health -= 1;
            Destroy(gameObject);
        }
    }
}
