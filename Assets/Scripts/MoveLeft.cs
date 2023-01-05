using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15f;
    private float leftBound = -10f;
    private float scoreBound = -2f;
    private bool isScoreAdded = false;
    private PlayerController playerControllerScript;
    private ScoreManager scoreManagerScript;
    

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreManagerScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < scoreBound && gameObject.CompareTag("Obstacle") && !isScoreAdded)
        {
            
            scoreManagerScript.score += 5;
            isScoreAdded = true;
            
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            isScoreAdded = false;
            Destroy(gameObject);
        }


    }
}
