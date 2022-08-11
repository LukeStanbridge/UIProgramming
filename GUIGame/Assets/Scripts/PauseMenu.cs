using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public PlayerMovement playerMovement;

    [Header("Pause Child Components")]
    public GameObject pauseMenu;
    public GameObject pauseSettings;
    public GameObject pauseInstructions;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void PauseMenuOption(string buttonName)
    {
        switch (buttonName)
        {
            case "Resume":
                Resume();
                break;

            case "How To Play":
                HowToPlay();
                break;

            case "Settings":
                Settings();
                break;

            case "Exit Game":
                ExitGame();
                break;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseMenu.SetActive(false);
        pauseSettings.SetActive(false);
        pauseInstructions.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerMovement.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerMovement.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Settings()
    {
        pauseMenu.SetActive(false);
        pauseSettings.SetActive(true);
    }

    void HowToPlay()
    {
        pauseMenu.SetActive(false);
        pauseInstructions.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerMovement.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }
}
