using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public float score;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCalculator();
    }

    void ScoreCalculator()
    {
        if (playerControllerScript.gameOver == false)
        { 
        // score increases every second by 1
        score += Time.deltaTime;
        scoreText.text = $"Score: {(int)score}";
        }
    }
}
