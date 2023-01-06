using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float introductionSecs = 4f;

    private float elapsedSecs;

    private GameObject player;
    private Animator playerAnim;
    private GameObject background;
    private GameObject spawnManager;
    private GameObject scoreManager;

    private bool isGameStart;

    private Vector3 preStartPos;
    private Vector3 startPos = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        background = GameObject.Find("Background");
        spawnManager = GameObject.Find("SpawnManager");
        scoreManager = GameObject.Find("ScoreManager");
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
        preStartPos = player.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        // used if statement to stop counting for no reason after 2 sec
        if (elapsedSecs < 3)
        {
            elapsedSecs += Time.deltaTime;
            playerAnim.SetFloat("Speed_f", elapsedSecs);
        }


        // for the Player walks in and start running
        if (!isGameStart )
        {
            player.transform.position = Vector3.Lerp(preStartPos, startPos, elapsedSecs / introductionSecs);
            background.GetComponent<MoveLeft>().enabled = false;
            spawnManager.GetComponent<SpawnManager>().enabled = false;
            scoreManager.GetComponent<ScoreManager>().enabled = false;

            if (elapsedSecs > introductionSecs)
            {
                background.GetComponent<MoveLeft>().enabled = true;
                spawnManager.GetComponent<SpawnManager>().enabled = true;
                scoreManager.GetComponent<ScoreManager>().enabled = true;

                isGameStart = true;
            }
        }
    }
}
