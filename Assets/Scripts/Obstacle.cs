using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float obstacleSpeed = 1f;

    private int timeToDestroyObject = 7;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.curentGameState == GameState.InGame)
        {
            transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;
        }
    }

    private void OnBecameInvisible()
    {
        if (GameManager.instance.curentGameState == GameState.InGame)
        {
            Destroy(gameObject, timeToDestroyObject);
        }
    }

}
