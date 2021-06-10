using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
    }
}
