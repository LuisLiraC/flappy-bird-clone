using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum OptionType
{
    PlayerSkin,
    PipeSkin
}
public class OptionsUIManager : MonoBehaviour
{
    public static OptionsUIManager instance;

    [Header("Skins")]
    [SerializeField] private List<Button> playerSkinsButtons;
    [SerializeField] private List<Button> pipesSkinsButtons;

    [Header("Canvas")]
    [SerializeField] private Canvas modalCanvas;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        modalCanvas.enabled = false;
    }

    private void Start()
    {
        SelectOption(
            PlayerPrefs.GetInt("player_skin", 0),
            OptionType.PlayerSkin
            );
        SelectOption(
            PlayerPrefs.GetInt("pipe_skin", 0),
            OptionType.PipeSkin
            );
    }

    public void SelectOption(int option, OptionType type)
    {
        Button selectedButton = null;
        switch (type)
        {
            case OptionType.PlayerSkin:
                selectedButton = playerSkinsButtons[option];
                DeselectRemainingOptions(option, playerSkinsButtons);
                break;
            case OptionType.PipeSkin:
                selectedButton = pipesSkinsButtons[option];
                DeselectRemainingOptions(option, pipesSkinsButtons);
                break;
        }
        
        if (selectedButton != null)
        {
            var background = selectedButton.gameObject.transform.GetChild(0).gameObject;
            background.GetComponent<Image>().enabled = true;
        }
    }

    private void DeselectRemainingOptions(int index, List<Button> buttons)
    {
        List<Button> targetButtons = new List<Button>();
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i != index)
            {
                targetButtons.Add(buttons[i]);
            }
        }

        foreach (Button button in targetButtons)
        {
            var background = button.gameObject.transform.GetChild(0).gameObject;
            background.GetComponent<Image>().enabled = false;
        }
    }


    public void ShowModal()
    {
        modalCanvas.enabled = true;
        modalCanvas.sortingOrder = 2;
    }

    public void CloseModal()
    {
        modalCanvas.enabled = false;
        modalCanvas.sortingOrder = -1;
    }
}
