using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    //<---SECTION A: CLASS VARIABLES--->

    //Variables at the top of the class are called "static variables" or "class variables"
    //for this template, we will be calling them class variables.
    //let's go over what class variables we have!


    /* These are our Vector3 variables. Vector3s store 3 floats: an x, y, and z.
     * verticalMovement is the vector for our vertical (up and down) movement on the Y-Axis
     * horizontalMovement is the vector for our horizontal (left and right) movement on the X-Axis
     */
    public Vector3 verticalMovement;
    public Vector3 horizontalMovement;



    //This GameObject stores our bullet prefab so that our player can spawn bullets.
    public GameObject bulletPrefab;


    /* This is a reference to our GameManagerScript
     * This allows us to change the class variables inside of that script FROM this script.
     * We can also call methods from that script within this script.
     */
    public GameManagerScript gmScript;



    //This integer variables keeps track of our player's health.
    //If this int reaches 0, our player dies and we lose the game.
    public int health;


    


    //this integer will keep track of what direction the player is facing
    //it will store 1-4, for 4 different positions
    /* 1 = facing up
     * 2 = facing down
     * 3 = facing right
     * 4 = facing left
     */
    public int playerFacing;




    //<---SECTION B: THE START FUNCTION--->


    // Start is called before the first frame update
    void Start()
    {


        //This line gets the GameManager OBJECT and then gets the GameManagerScript COMPONENT attached to it.
        //Remember: Scripts are COMPONENTS that must be attached to GAMEOBJECTS.
        //TODO

    }




    //<---SECTION C: THE UPDATE FUNCTION--->


    // Update is called once per frame
    void Update()
    {

        /* This section controls the movement of the player
         * We are using "GetKey" because "GetKey" is true as long as the key is being HELD DOWN
         * You can change the KeyCodes if you want to change the controls
         * OR you can use the "||" operand to add more controls into the if statement.
         */

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += verticalMovement;
            playerFacing = 1;
        }

        //S Key subtracts verticalMovement from our position and changes our playerFacing.
        if (Input.GetKey(KeyCode.S))
        {
            //TODO
        }


        //D Key adds horizontalMovement from our position and changes our playerFacing.
        if (//TODO)
        {
            //TODO
        }

        //A Key subtracts horizontalMovement from our position and changes our playerFacing.
        if (//TODO)
        {
            //TODO
        }






        /* This section controls shooting bullets
         * We are using "GetKeyDown" because it is true as long as the key is PRESSED ONCE.
         * This is different from GetKey because we do not want to hold down the button and shoot infinite bullets.
         * You can do that if you like, but you would have to implement a short cooldown between shots.
         */

        //Check using GetKeyDown if the Spacebar has been pressed
        if (//TODO)
        {
            //Call the custom Shoot method.
            //TODO
        }







        //If our player's health reaches zero or lower.
        if (//TODO)
        {
            //Stop the time in game.
            //TODO

            //Change the "playerWins" variable inside of the GameManagerScript to "false"
            //our player died, so they did not win.
            //TODO

            //Run the "EndGame" function inside of the GameManagerScript.
            //TODO
        }





    }


    //<---SECTION C: CUSTOM FUNCTION--->


    /* This is a custom function. Unity gives you Start and Update and also comes with built-in ones such as GameObject.Find, GetComponent, etc.
     * Custom functions hold code that all run when you call the function.
     * This makes your code better organized and modular, since you can call this code whenever you want rather than rewriting it over and over.
     */
    void Shoot()
    {

        //"Instantiate" is a Unity function that takes a prefab, makes a copy of it, and places it at the position you specify
        //"Quaternion.identity" means "do not change the rotation of the prefab"
        //This bullet will spawn at the position of our PLAYER, since transform.position refers to the position of the object...
        //...that this script is attached to, which in this case is the player.
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);




        /* These 4 if-blocks check what direction our player is facing. There are 4 total directions: up, down, left, right.
         * We need the bullets to go in the direction that we are facing.
         */
        if (playerFacing == 1)
        {
            bullet.GetComponent<BulletScript>().bulletSpeed = new Vector3(0 , 0.01f , 0);
        }
        else if (//TODO)
        {
            bullet.GetComponent<BulletScript>().bulletSpeed = new Vector3(0, -0.01f, 0);
        }
        else if (//TODO)
        {
            bullet.GetComponent<BulletScript>().bulletSpeed = new Vector3(0.01f, 0, 0);
        }
        else if (//TODO)
        {
            bullet.GetComponent<BulletScript>().bulletSpeed = new Vector3(-0.01f, 0, 0);
        }







    }

}
