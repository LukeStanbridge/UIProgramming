using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public PanelGroup panelGroup;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter (TabButton button)
    {
        
    }

    public void OnTabExit(TabButton button)
    {

    }

    public void OnTabSelected(TabButton button)
    {
        if (panelGroup != null)
        {
            panelGroup.SetPageIndex(tabButtons.IndexOf(button));
        }
    }

   
}
