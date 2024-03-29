using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    //<---SECTION A: CLASS VARIABLES--->

    //Variables at the top of the class are called "static variables" or "class variables"
    //for this template, we will be calling them class variables.
    //let's go over what class variables we have!


    /* These floats will hold values for our timers.
     * gameTimer will hold the total time that the game has been running in seconds and milliseconds.
     * enemySpawnTimer will hold the total time since an enemy has been spawned in.
     */
    public float gameTimer;
    public float enemySpawnTimer;


    /* These bools hold information for our game's win or lose state
     * gameOver holds whether the game has ended.
     * playerWins holds whether our player has won or lost the game after it ends.
     */
    public bool gameOver;
    public bool playerWins;


    //This GameObject variable holds our enemy prefab object, that we will then spawn in.
    public GameObject enemyPrefab;


    /* This List object holds the GameObjects for our enemy spawn points.
    *  A List is a special variable that can hold multiple variables inside of it.
    *  Instead of making individual variables, you can make a list that holds them together.
    *  You can change the contents of this list in the inspector.
    */
    public List<GameObject> enemySpawnPositions;
    

    //This TMP_Text variable will hold our game over text.
    //The text will change based on the playerWins bool.
    public TMP_Text gameEndText;

    


    //<---SECTION B: THE START FUNCTION--->

    // Start is called before the first frame update
    void Start()
    {

        //Set our gameTimer variable to 0.
        gameTimer = 0;

        //Set our gameOver variable to false.
        //The game has just started, so it isn't over.
        gameOver = false;
    }


    //<---SECTION C: THE UPDATE FUNCTION--->

    // Update is called once per frame
    void Update()
    {


        /* The code below makes the timers count up from the beginning of the game.
         * gameTimer is keeping track of how long the game is running.
         * enemySpawnTimer is keeping track of when to spawn enemies.
         */
        gameTimer += Time.deltaTime;
        enemySpawnTimer += Time.deltaTime;



        /* The code below should spawn an enemyPrefab every 5 seconds.
         * The spawn position of the enemy is a random spawnpoint in the enemySpawnPositions list.
         * The enemy timer should reset back to zero.
         */
        if (enemySpawnTimer >= 2)
        {
            Instantiate(enemyPrefab, enemySpawnPositions[UnityEngine.Random.Range(0, enemySpawnPositions.Count)].transform.position, Quaternion.identity);
            enemySpawnTimer = 0;
        }



        /* This if-statement evaluates whether 30 seconds have elapsed.
         * If 30 seconds have elapsed, the player wins!
         */
        if (gameTimer >= 30)
        {
            //Set the playerWins and gameOver bools to "true"
            playerWins = true;
            gameOver = true;
        }



        /* this if-statement evaluates whether the game has ended.
         * the game can end in two ways:
         * 1. If 30 seconds pass and the player is still alive
         * 2. If the player's health falls to 0 and they die.
         */
        if (gameOver == true)
        {
            //Run the EndGame function.
            EndGame();

            //This if-statement evaluates whether the player has pressed the "R" key.
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Reload the scene using the SceneManager so the player can play again.
                SceneManager.LoadScene("GameScene");
            }


        }

        


    }


    //<---SECTION D: OUR CUSTOM FUNCTION--->


    /* This is a custom function that we have created for you to fill in.
     * This function runs code that helps end the game.
     * This function is of the type "void" which means that it does not return any values.
     * It runs the code and that's it.
     */
    public void EndGame()
    {

        //Freeze time.
        Time.timeScale = 0;

        //Show the game end text GameObject
        gameEndText.gameObject.SetActive(true);


        //This if-statement evaluates whether the player won.
        if (playerWins == true) { 

            //change the gameEndText to say "You win!"
            gameEndText.text = "You Win\nPress R to restart";
        }


        //if the if-statement evaluates to false
        else
        {
            //change the gameEndText to say "You lose!"
            gameEndText.text = "You Lose\nPress R to restart";
        }

    }
}
