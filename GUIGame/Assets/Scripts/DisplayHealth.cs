using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DisplayHealth : MonoBehaviour
{
    public UnityEvent onChanged;
    public GameObject lifePrefab;
    public int lives = 3;
    List<GameObject> icon = new List<GameObject>();

    LayoutGroup layoutGroup;
    ContentSizeFitter contentSizeFitter;

    // Start is called before the first frame update
    void Start()
    {
        layoutGroup = GetComponent<LayoutGroup>();
        contentSizeFitter = GetComponent<ContentSizeFitter>();
        StartCoroutine(UpdateUI());

        onChanged.AddListener(() => { StartCoroutine(UpdateUI()); });   
    }

    IEnumerator UpdateUI()
    {
        contentSizeFitter.enabled = true;
        layoutGroup.enabled = true;

        yield return new WaitForEndOfFrame();

        // step through the dictionary, and remove any uis associated with actions no longer in our list
        for (int i = 0; i < lives; i++)
        {
            if (i >= icon.Count) icon.Add(Instantiate(lifePrefab, transform));
            icon[i].gameObject.SetActive(true);
            icon[i].transform.SetAsLastSibling();
        }

        for (int i = lives; i < icon.Count; i++) icon[i].gameObject.SetActive(false);

        yield return new WaitForEndOfFrame();

        contentSizeFitter.enabled = false;
        layoutGroup.enabled = false;
    }

    [ContextMenu("Remove Life")]
    void RemoveLife()
    {
        lives--;
        onChanged.Invoke();
    }

    [ContextMenu("Add Life")]
    void AddLife()
    {
        lives++;
        onChanged.Invoke();
    }
}
