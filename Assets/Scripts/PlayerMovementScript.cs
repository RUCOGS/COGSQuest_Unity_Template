using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public Vector3 verticalMovement;
    public Vector3 horizontalMovement;

    public GameObject bulletPrefab;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= verticalMovement;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += horizontalMovement;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= horizontalMovement;
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

    }


    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

}
