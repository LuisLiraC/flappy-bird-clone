using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Global")]
    [SerializeField] private GameObject floor;
    private Animator floorAnimator;

    [Header("Menu View")]
    [SerializeField] private Canvas menuCanvas;

    [Header("Game View")]
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Image readyTitle;
    [SerializeField] private Image instructions;
    [SerializeField] private Text pointsText;

    [Header("Game Over View")]
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Text gamePoints;
    [SerializeField] private Text maxScoreText;
    [SerializeField] private Image newScoreSprite;
    [SerializeField] private Image medalContainer;
    [SerializeField] private List<Sprite> medals;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        gameCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        newScoreSprite.enabled = false;
    }

    private void Start()
    {
        floorAnimator = floor.gameObject.GetComponent<Animator>();
    }

    public void UpdateScore(int score)
    {
        pointsText.text = score.ToString();
        gamePoints.text = score.ToString();
    }

    public void ShowGameCanvas()
    {
        gameCanvas.enabled = true;
    }

    public void HideGameCanvas()
    {
        gameCanvas.enabled = false;
    }

    public void ShowMenuCanvas()
    {
        menuCanvas.enabled = true;
    }

    public void HideMenuCanvas()
    {
        menuCanvas.enabled = false;
    }

    public void ShowGameOverCanvas()
    {
        gameOverCanvas.enabled = true;
        maxScoreText.text = PlayerPrefs.GetInt("max_score", 0).ToString();
        StartCoroutine(ToggleButtons());
    }

    IEnumerator ToggleButtons()
    {
        GameObject restartButton = gameOverCanvas.gameObject.transform.GetChild(0).gameObject;
        GameObject menuButton = gameOverCanvas.gameObject.transform.GetChild(1).gameObject;
        GameObject exitButton = gameOverCanvas.gameObject.transform.GetChild(2).gameObject;
        restartButton.GetComponent<Image>().enabled = false;
        menuButton.GetComponent<Image>().enabled = false;
        exitButton.GetComponent<Image>().enabled = false;

        yield return new WaitForSeconds(1f);

        restartButton.GetComponent<Image>().enabled = true;
        menuButton.GetComponent<Image>().enabled = true;
        exitButton.GetComponent<Image>().enabled = true;
    }

    public void HideGameOverCanvas()
    {
        gameOverCanvas.enabled = false;
    }

    public void ShowNewScoreSprite()
    {
        newScoreSprite.enabled = true;
    }

    public void HideNewScoreSprite()
    {
        newScoreSprite.enabled = false;
    }

    public void StopFloorAnimation()
    {
        floorAnimator.enabled = false;
    }

    public void StartFloorAnimation()
    {
        floorAnimator.enabled = true;
    }

    public void HideInstructions()
    {
        pointsText.enabled = false;
        StartCoroutine(HideAssets());
    }

    public void ShowInstructions()
    {
        readyTitle.enabled = true;
        instructions.enabled = true;
    }

    IEnumerator HideAssets()
    {
        yield return new WaitForSeconds(1.5f);
        readyTitle.enabled = false;
        instructions.enabled = false;
        pointsText.enabled = true;
    }

    public void ShowMedal(int score)
    {
        medalContainer.enabled = true;
        switch (score)
        {
            case int n when (n < 10):
                medalContainer.enabled = false;
                break;
            case int n when (n >= 10 && n < 20):
                medalContainer.sprite = medals[0];
                break;
            case int n when (n >= 20 && n < 30):
                medalContainer.sprite = medals[1];
                break;
            case int n when (n >= 30 && n < 40):
                medalContainer.sprite = medals[2];
                break;
            case int n when (n >= 40):
                medalContainer.sprite = medals[3];
                break;
        }
    }
}
