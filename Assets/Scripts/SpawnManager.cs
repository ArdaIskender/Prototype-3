using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject []obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        if (playerControllerScript.gameOver == false)
        {
            int prefab = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[prefab], spawnPos, obstaclePrefab[prefab].transform.rotation);
        }
        
    }
}
