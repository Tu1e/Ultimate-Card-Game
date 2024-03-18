using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Deck : MonoBehaviour
{
    public Transform hand;
    [SerializeField] int cardsInDeck = 30, cardsLeft = 30;
    public bool canDraw = false;
    public List<Card> decK;
    PhotonView view;
    [SerializeField] Hand handInstance;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject Card;
    [SerializeField] int startHandSize;
    public bool isMaster = PhotonNetwork.IsMasterClient;
    void Start()
    {
        view = GetComponent<PhotonView>();
        cardsInDeck = decK.Count;
        cardsLeft = cardsInDeck;
        DeckShuffle();
        StartingHand();
    }

    private void Update()
    {
        Debug.Log(cardsLeft);
        /*if (canDraw)
        {
            Draw();
        }*/
    }

    private void OnMouseDown()
    {
        if (view.IsMine && canDraw)
        {
            Debug.Log(this.name + "draws");
            Draw();
        }
    }

    void DeckShuffle()
    {
        System.Random rng = new System.Random();
        int n = decK.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = decK[k];
            decK[k] = decK[n];
            decK[n] = value;
        }
    }

    void StartingHand()
    {
        for(int i = 0; i < startHandSize; i++)
        {
            Draw();
        }
    }
    public void Draw()
    {
        if(cardsLeft == 0)
        {
            Debug.Log("You Loose!");
            return;
        }

        cardsLeft--;
        GameObject cardGameObject = PhotonNetwork.Instantiate("Card",hand.transform.position, Quaternion.identity);
        cardGameObject.transform.parent = canvas.transform;
        cardGameObject.GetComponent<CardDisplay>().card = decK[decK.Count - 1];
        handInstance.AddCardToHand(cardGameObject);
        decK.Remove(decK[decK.Count-1]);
    }
}
