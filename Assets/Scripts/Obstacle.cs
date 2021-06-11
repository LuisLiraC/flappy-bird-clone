using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float obstacleSpeed = 1f;

    [SerializeField]
    private List<Sprite> pipesUp;

    [SerializeField]
    private List<Sprite> pipesDown;

    private int timeToDestroyObject = 7;

    private void Start()
    {
        SetPipesSkin();
    }
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

    private void SetPipesSkin()
    {
        int i = PlayerPrefs.GetInt("pipe_skin", 0);
        var pipeDown = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        var pipeUp = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        pipeDown.sprite = pipesDown[i];
        pipeUp.sprite = pipesUp[i];
    }

}
