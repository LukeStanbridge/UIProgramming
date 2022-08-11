using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public GameObject menu;
    public void ToggleScreen()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        menu.SetActive(true);
    }
}
