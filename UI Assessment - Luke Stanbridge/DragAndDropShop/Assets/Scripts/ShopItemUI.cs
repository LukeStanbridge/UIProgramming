using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;

    ShopItem item;

    public bool dragging;
    public Transform originalParent;
    public Canvas canvas;

    public Slot slot;

    List<RaycastResult> hits = new List<RaycastResult>();

    public void SetItem(ShopItem i)
    {
        item = i;
        if (image)
        {
            if (item)
            {
                image.sprite = item.icon;
                image.color = item.color;
            }
            gameObject.SetActive(item != null);
        }
    }

    protected void Swap(Slot newParent)
    {
        ShopItemUI other = newParent.item as ShopItemUI;
        if (other)
        {
            ShopItem ours = item;
            ShopItem theirs = other.item;

            slot.UpdateItem(theirs);
            other.slot.UpdateItem(ours);
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (originalParent == null) originalParent = transform.parent;
        if (canvas == null) canvas = GetComponentInParent<Canvas>();
        transform.SetParent(canvas.transform, true);
        transform.SetAsLastSibling();
        dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragging) transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // is there a slot underneath us?
        Slot slotFound = null;
        EventSystem.current.RaycastAll(eventData, hits);
        foreach (RaycastResult hit in hits)
        {
            Slot s = hit.gameObject.GetComponent<Slot>();
            if (s) slotFound = s;
        }

        if (slotFound != null)
        {
            Swap(slotFound);
            transform.SetParent(originalParent.transform, true);
            transform.localPosition = Vector3.zero;
        }
        else
        {
            transform.SetParent(originalParent.transform, true);
            transform.localPosition = Vector3.zero;
        }
    }
}
