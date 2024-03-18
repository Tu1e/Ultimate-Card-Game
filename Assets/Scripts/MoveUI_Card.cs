using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveUI_Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    int cardState = 0;
    CardSlot slot;
    Transform slotPos;
    //card states range form 0 to 2 0 = default state [in hand/not played]; 1 = on the field [palyed/on card slot]; 2 = fliped up / activated

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (cardState != 0)
            return;
        // Set the UI element as being dragged
        eventData.pointerDrag = gameObject;
        rectTransform.SetAsLastSibling(); // Move the UI element to the front
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move UI element with cursor
        Vector2 mouseDelta = eventData.delta;
        rectTransform.anchoredPosition += mouseDelta;
    }
    public void SpotFound(GameObject obj)
    {
        if (obj != null)
        {
            slot = obj.GetComponent<CardSlot>();
            slotPos = obj.transform;

            return;
        }
        Debug.Log("CardSlot not found");

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(slotPos != null)
        {
            rectTransform.position = slotPos.position;
        }
    }
}

