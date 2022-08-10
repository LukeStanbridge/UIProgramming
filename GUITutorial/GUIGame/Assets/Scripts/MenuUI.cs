using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    public MenuOption button;

    [Header("Child Components")]
    public Image colour;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI descriptionTag;

    Player player;

    private void Start()
    {
        SetButton(button);
    }

    public void Init(Player p)
    {
        // store the player ref for use in our lambda function below
        player = p;
        // find the button wherever we've placed it in the prefab
        // for more complicated types of prefabs with multiple buttons, we'd make this a public member
        // and hook it up in the Unity editor
        Button buttonClick = GetComponentInChildren<Button>();
        if (buttonClick)
            buttonClick.onClick.AddListener(() => { player.ChooseButton(button); });
    }

    public void SetButton(MenuOption b)
    {
        button = b;
        if (button == null) return;
        if (nameTag)
            nameTag.text = button.buttonName;
        if (descriptionTag)
            descriptionTag.text = button.description;
        if (colour)
        {
            colour.color = button.color;
        }
    }
}
