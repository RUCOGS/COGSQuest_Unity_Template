using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    public int score;

    public float gameTimer;
    public float enemySpawnTimer;

    public bool gameOver;

    public int highScore;

    public GameObject enemyPrefab;


    public List<GameObject> enemySpawnPositions;


    public TMP_Text gameEndText;

    public bool playerWins;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 0;
        gameOver = false;
    }

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
        if (enemySpawnTimer >= 5)
        {
            Instantiate(enemyPrefab, enemySpawnPositions[UnityEngine.Random.Range(0, enemySpawnPositions.Count)].transform.position, Quaternion.identity);
            enemySpawnTimer = 0;
        }




        if (gameOver == true)
        {
            EndGame();
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Restart the game
            }
        }

        


    }

    /* This function runs code that helps end the game.
     */

    void EndGame()
    {
        //Freeze time.
        Time.timeScale = 0;
        gameEndText.gameObject.SetActive(true);

        if (playerWins == true)
        {
            gameEndText.text = "You Win";
        }

        else
        {
            gameEndText.text = "You Lose";
        }

    }
}
