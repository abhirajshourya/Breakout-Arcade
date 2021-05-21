using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //cached references
    GameSession gameStatus;
    public void LoadNextScreen()
    {
        int curerentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curerentSceneIndex+1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
