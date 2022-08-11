using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Main Menu Child Components")]
    public GameObject menu;
    public GameObject settings;
    public GameObject instructions;

    [Header("Pause Child Components")]
    public PauseMenu pauseUI;

    private new string name;

    public void ChooseButton(MenuOption button)
    {
        name = button.buttonName;
        Debug.Log("Doing " + name);

        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Game") pauseUI.PauseMenuOption(name);
        else MainMenuOption(name);
    }
    public void MainMenuOption(string buttonName)
    {
        switch (buttonName)
        {
            case "Start":
                SceneManager.LoadScene("Game");
                break;

            case "How To Play":
                menu.SetActive(false);
                instructions.SetActive(true);
                break;

            case "Settings":
                menu.SetActive(false);
                settings.SetActive(true);
                break;

            case "Exit":
                Application.Quit();
                break;
        }
    }
}
