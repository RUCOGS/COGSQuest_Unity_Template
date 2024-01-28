using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public Vector3 verticalMovement;
    public Vector3 horizontalMovement;

    public GameObject bulletPrefab;

    public GameManagerScript gmScript;

    public int health;

    //this integer will keep track of what direction the player is facing
    //it will store 1-4, for 4 different positions
    /* 1 = facing up
     * 2 = facing down
     * 3 = facing right
     * 4 = facing left
     */
    public int playerFacing;

    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

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

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= verticalMovement;
            playerFacing = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += horizontalMovement;
            playerFacing = 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= horizontalMovement;
            playerFacing = 4;
        }


        /* This section controls shooting bullets
         * We are using "GetKeyDown" because it is true as long as the key is PRESSED ONCE.
         * This is different from GetKey because we do not want to hold down the button and shoot infinite bullets.
         * You can do that if you like, but you would have to implement a short cooldown between shots.
         */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //This is a custom function that we have created.
            Shoot();
        }


        //If our player's health reaches zero.
        if (health <= 0)
        {
            //This line stops time in-game.
            Time.timeScale = 0;

            //This tells the GameManager that the player lost.
            gmScript.playerWins = false;

            //This runs our "EndGame" custom function from the GameManagerScript.
            gmScript.EndGame();
        }

    }


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
            bullet.GetComponent<BulletScript>().bulletSpeed = new Vector3(0,0.01f);
        }
        else if (playerFacing == 2)
        {
            bullet.GetComponent<BulletScript>().bulletSpeed = new Vector3(0, -0.01f);
        }
        else if (playerFacing == 3)
        {
            bullet.GetComponent<BulletScript>().bulletSpeed = new Vector3(0.01f, 0);
        }
        else if (playerFacing == 4)
        {
            bullet.GetComponent<BulletScript>().bulletSpeed = new Vector3(-0.01f, 0);
        }


        
    }

}
