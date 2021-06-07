using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu,
    InGame,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public GameState curentGameState = GameState.Menu;
    public static GameManager instance;
    private PlayerController playerController;
    private int playerPoints = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void SetGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:
                // TODO
                break;
            case GameState.InGame:
                UIManager.instance.HideMenuCanvas();
                UIManager.instance.HideGameOverCanvas();
                UIManager.instance.ShowGameCanvas();
                UIManager.instance.StartFloorAnimation();
                UIManager.instance.HideInstructions();
                playerController.StartGame();
                ObstacleGenerator.instance.DeleteObstacles();
                break;
            case GameState.GameOver:
                UIManager.instance.HideNewScoreSprite();
                UIManager.instance.StopFloorAnimation();
                int maxScore = PlayerPrefs.GetInt("max_score", 0);

                UIManager.instance.ShowMedal(playerPoints);

                if (playerPoints > maxScore) 
                {
                    PlayerPrefs.SetInt("max_score", playerPoints);
                    UIManager.instance.ShowNewScoreSprite();
                }

                UIManager.instance.HideGameCanvas();
                UIManager.instance.ShowGameOverCanvas();
                break;
        }

        curentGameState = gameState;
    }

    public void StartGame()
    {
        if (curentGameState != GameState.InGame)
        {
            SetGameState(GameState.InGame);
            playerPoints = 0;
            UIManager.instance.UpdateScore(playerPoints);
        }
    }

    public void AddPlayerPoints(int points)
    {
        playerPoints += points;
        UIManager.instance.UpdateScore(playerPoints);
    }

}
