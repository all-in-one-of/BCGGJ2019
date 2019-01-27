using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Menu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
    }

    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }
}
