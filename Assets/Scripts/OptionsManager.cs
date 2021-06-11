using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionsManager : MonoBehaviour
{
    public void SetYellowPlayerSkin()
    {
        int i = 0;
        SetPlayerSkinPref("player_skin", i);
        OptionsUIManager.instance.SelectOption(i, OptionType.PlayerSkin);
    }
    public void SetBluePlayerSkin()
    {
        int i = 1;
        SetPlayerSkinPref("player_skin", i);
        OptionsUIManager.instance.SelectOption(i, OptionType.PlayerSkin);
    }
    public void SetRedPlayerSkin()
    {
        int i = 2;
        SetPlayerSkinPref("player_skin", i);
        OptionsUIManager.instance.SelectOption(i, OptionType.PlayerSkin);
    }

    public void SetGreenPipeSkin()
    {
        int i = 0;
        SetPlayerSkinPref("pipe_skin", i);
        OptionsUIManager.instance.SelectOption(i, OptionType.PipeSkin);
    }

    public void SetBrownPipeSkin()
    {
        int i = 1;
        SetPlayerSkinPref("pipe_skin", i);
        OptionsUIManager.instance.SelectOption(i, OptionType.PipeSkin);
    }

    public void ResetMaxScore()
    {
        PlayerPrefs.SetInt("max_score", 0);
    }
    private void SetPlayerSkinPref(string prefName, int n) => PlayerPrefs.SetInt(prefName, n);
}
