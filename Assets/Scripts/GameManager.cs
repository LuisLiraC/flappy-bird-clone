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
        Application.targetFrameRate = 60;
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void SetGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Menu:
                UIManager.instance.ShowMenuCanvas();
                UIManager.instance.HideGameOverCanvas();
                UIManager.instance.HideGameCanvas();

                UIManager.instance.StartFloorAnimation();
                ObstacleGenerator.instance.DeleteObstacles();

                UIManager.instance.ShowInstructions();

                playerController.InitialState();
                break;
            case GameState.InGame:
                UIManager.instance.HideMenuCanvas();
                UIManager.instance.HideGameOverCanvas();
                UIManager.instance.ShowGameCanvas();

                UIManager.instance.StartFloorAnimation();
                ObstacleGenerator.instance.DeleteObstacles();

                UIManager.instance.HideInstructions();
                playerController.StartGame();
                
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

    public void BacktoMenu()
    {
        SetGameState(GameState.Menu);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void ApplyPrefs()
    {
        playerController.SetSkin();
    }

}
