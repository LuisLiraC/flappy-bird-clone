using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    public Canvas menuCanvas;

    [SerializeField]
    public Canvas gameCanvas;

    [SerializeField]
    public Canvas gameOverCanvas;

    [SerializeField]
    private Text pointsText;

    [SerializeField]
    private Text gamePoints;

    [SerializeField]
    private Text maxScoreText;

    [SerializeField]
    private Image newScoreSprite;

    [SerializeField]
    private GameObject floor;

    private Animator floorAnimator;

    [SerializeField]
    private Image readyTitle;

    [SerializeField]
    private Image instructions;

    [SerializeField]
    private Image medalContainer;

    [SerializeField]
    private List<Sprite> medals;


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
        maxScoreText.text = PlayerPrefs.GetInt("max_score", 0).ToString();
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
