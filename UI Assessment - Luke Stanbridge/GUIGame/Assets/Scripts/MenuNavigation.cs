using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    [Header("Main Menu Child Components")]
    public TabGroup menu;

    [Header("Pause Child Components")]
    public PauseMenu pauseUI;

    // switch statement to give funtionality to menu options
    public void MainMenuOption(string buttonName)
    {
        switch (buttonName)
        {
            case "Play":
                SceneManager.LoadScene("Game");
                break;

            case "How To Play":
                menu.panelNumber = 6;
                break;

            case "Settings":
                menu.panelNumber = 7;
                break;

            case "Load":
                menu.panelNumber = 8;
                break;

            case "Quit":
                Application.Quit();
                break;

            case "Back":
                menu.panelNumber = 0;
                break;

            case "Resume":
                pauseUI.Resume();
                break;

            case "Exit":
                pauseUI.ExitGame();
                break;
        }
    }
}
