using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public GameObject instructions;
    public void ChooseButton(MenuOption button)
    {
        Debug.Log("Doing " + button.buttonName);

        if (button.buttonName == "Settings")
        {
            menu.SetActive(false);
            settings.SetActive(true);
        }
        else if (button.buttonName == "How To Play")
        {
            menu.SetActive(false);
            instructions.SetActive(true);
        }
    }
}
