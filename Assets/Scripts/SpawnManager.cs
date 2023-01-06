using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private PlayerController playerControllerScript;
    // private ScoreManager scoreManagerScript;

    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 2f;
    private float repeatRate = 2f;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
     //   scoreManagerScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int prefab = Random.Range(0, obstaclePrefab.Length);

            // If obstacle gonna be a box, there is chance to spawn two boxes together
            if (prefab == 1)
            {
                int howManyBox = Random.Range(1, 3);
                if (howManyBox == 1)
                {
                    Instantiate(obstaclePrefab[prefab], spawnPos, obstaclePrefab[prefab].transform.rotation);
                }
                if (howManyBox == 2)
                {
                    float boxSizeY = obstaclePrefab[prefab].GetComponent<BoxCollider>().size.y;
                    Vector3 spawnPos2 = new Vector3(spawnPos.x, spawnPos.y + boxSizeY, spawnPos.z);
                    Instantiate(obstaclePrefab[prefab], spawnPos, obstaclePrefab[prefab].transform.rotation);
                    Instantiate(obstaclePrefab[prefab], spawnPos2, obstaclePrefab[prefab].transform.rotation);
                }
                if (howManyBox == 3)
                {
                    float boxSizeY = obstaclePrefab[prefab].GetComponent<BoxCollider>().size.y;
                    Vector3 spawnPos2 = new Vector3(spawnPos.x, spawnPos.y + boxSizeY, spawnPos.z);
                    Instantiate(obstaclePrefab[prefab], spawnPos, obstaclePrefab[prefab].transform.rotation);
                    Instantiate(obstaclePrefab[prefab], spawnPos2, obstaclePrefab[prefab].transform.rotation);
                }
            

            }
            else
            {
                Instantiate(obstaclePrefab[prefab], spawnPos, obstaclePrefab[prefab].transform.rotation);
            }
        }

    }
}
