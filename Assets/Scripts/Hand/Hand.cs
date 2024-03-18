using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Hand : MonoBehaviour
{
    [SerializeField] List<GameObject> cardsInHand = new List<GameObject>(); 
    [SerializeField] Transform hand1Position, hand2Position;
    [SerializeField] float cardDistance;
    public bool isMaster = PhotonNetwork.IsMasterClient;
    void Start()
    {
        AdjustCards();
    } 

    
    void FixedUpdate()
    {
       // AjustCards();
    }

    public void AddCardToHand(GameObject card)
    {
        cardsInHand.Add(card);
        AdjustCards();
    }
    public void AdjustCards()
    {
        int numCards = cardsInHand.Count;
        float centerOffset = 0.5f;
    
        if (numCards % 2 == 0) // Even number of cards
        {
            centerOffset = 0.5f - 1.0f / (numCards * 2);
        }

        for(int i = 0; i < numCards; i++)
        {
            float xOffset = i - (numCards - 1) * centerOffset;
            cardsInHand[i].transform.position = new Vector2(hand1Position.position.x + xOffset * cardDistance, hand1Position.position.y);
        }
    }
}
