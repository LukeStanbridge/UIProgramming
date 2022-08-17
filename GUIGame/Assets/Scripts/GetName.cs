using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetName : MonoBehaviour
{
    public GameObject parent;
    public TextMeshProUGUI textMeshPro;
    void Awake()
    {
        var parentName = transform.parent.name;
        textMeshPro.text = parentName;
    }
}
