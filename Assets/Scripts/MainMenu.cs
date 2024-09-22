using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1_Scene");

    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void OptionsGame()
    {

        SceneManager.LoadScene("MainOptionsScene");
    }

    public void BackGame()
    {

        SceneManager.LoadScene("MainMenuScene");

    }
    public void CreditsGame()
    {

        SceneManager.LoadScene("MainCreditsScene");

    }

}

