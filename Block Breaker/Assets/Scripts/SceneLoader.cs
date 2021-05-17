using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScreen()
    {
        int curerentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curerentSceneIndex+1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
