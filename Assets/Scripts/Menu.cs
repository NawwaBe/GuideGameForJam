using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LevelStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Die()
    {
        SceneManager.LoadScene("Restart");
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Exit");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void MenuM()
    {
        SceneManager.LoadScene("Menu");
    }
}
