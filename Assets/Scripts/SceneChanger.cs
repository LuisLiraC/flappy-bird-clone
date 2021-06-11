using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void BackToMenu()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
    }
}
