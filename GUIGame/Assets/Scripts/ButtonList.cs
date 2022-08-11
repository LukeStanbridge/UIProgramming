using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonList : MonoBehaviour
{
    public UnityEvent onChanged;
    MenuOption[] _buttons = null;

    public MenuOption[] buttons
    {
        get
        {
            if(_buttons == null) _buttons = GetComponents<MenuOption>();
            return _buttons;
        }
    }

    [ContextMenu("Delete First")]
    void DeleteFirst()
    {
        List<MenuOption> buttons = new List<MenuOption>(_buttons);
        buttons.RemoveAt(0);
        _buttons = buttons.ToArray();
        onChanged.Invoke();
    }
}
