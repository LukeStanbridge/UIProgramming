using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public PlayerMovement playerMovement;

    [Header("Pause Child Components")]
    public GameObject pauseMenu;
    public TabGroup tabGroup;

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

            case "Exit Game":
                ExitGame();
                break;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseMenu.SetActive(false);
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
        tabGroup.OnClosePauseMenu();
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerMovement.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
