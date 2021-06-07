using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private float obstacleHeightOffset = 1f;

    [SerializeField]
    private float maxTimeToSpawnObstacles = 1.7f;

    private float initialTimeToSpawnObstacles = 0;

    public static ObstacleGenerator instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.curentGameState == GameState.InGame)
        {
            if (initialTimeToSpawnObstacles > maxTimeToSpawnObstacles)
            {
                float randomHeight = Random.Range(-obstacleHeightOffset, obstacleHeightOffset);
                CreateObstacle(randomHeight);
                initialTimeToSpawnObstacles = 0;
            }
            else
            {
                initialTimeToSpawnObstacles += Time.deltaTime;
            }
        }
    }

    private void CreateObstacle(float heightOffset)
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = transform.position + new Vector3(0, heightOffset, 0);
    }

    public void DeleteObstacles()
    {
        var obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }
}