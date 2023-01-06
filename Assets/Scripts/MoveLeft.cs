using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private float leftBound = -10f;
    private float scoreBound = -2f;
    private bool isScoreAdded = false;
    private PlayerController playerControllerScript;
    private ScoreManager scoreManagerScript;
    public GameObject FloatingTextPrefab;

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
            // trigger floating text
            ShowFloatingText();
            // add score
            scoreManagerScript.score += 5;
            isScoreAdded = true;
            
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            isScoreAdded = false;
            Destroy(gameObject);
        }
        
        if (Input.GetKey(KeyCode.V))
        {
            speed = 30f;
            scoreManagerScript.score += (Time.deltaTime*25);
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            speed = 15f;
        }
    }

    void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
    }
}
