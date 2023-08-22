using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMenuController : MonoBehaviour
{
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void playGame()
    {
        SceneManager.LoadScene("Core");
    }

    public void CreaditGame()
    {
        SceneManager.LoadScene("Creadit");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
