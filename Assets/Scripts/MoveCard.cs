using UnityEngine;

public class MoveCard : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    CardSlot slot;
    Transform slotPos;

    void OnMouseDown()
    {
        // Set dragging to true and store the offset between the object's position and the cursor position
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Move the object based on the cursor position and the stored offset
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(cursorPosition.x + offset.x, cursorPosition.y + offset.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        if(slot != null && slot.empty == true)
        {
            transform.position = slotPos.position;
        }
    }

    public void SpotFound(GameObject obj)
    {
        if(obj != null)
        {
            slot = obj.GetComponent<CardSlot>();
            slotPos = obj.transform;

            return;
        }
        Debug.Log("CardSlot not found");
        
    }
}
