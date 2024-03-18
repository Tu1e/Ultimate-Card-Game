using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{   /*to do:
    -razlika izmedju playera
     
     */
    public bool empty = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            Debug.Log("karta u putanjiii");
            empty = true;

            MoveUI_Card moveCardComponent = other.gameObject.GetComponent<MoveUI_Card>();
            if (moveCardComponent != null && empty)
            {
                moveCardComponent.SpotFound(this.gameObject);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            empty = false;
        }
    }
}
