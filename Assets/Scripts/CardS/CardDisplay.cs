using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image cardImage;
    public Image wholeCard;
    public Sprite altImg;
    private PhotonView pView;

    int cardStage = 0; // 0 -> in hand; 1 -> on the field not active; 2 -> on field active

    public bool isMastersCard;
    void Start()
    {
        if(/*cardStage != 2 &&*/ !pView.IsMine)
        {
            wholeCard.sprite = altImg;
            cardImage.gameObject.active = false;
            return;
        }
        cardImage.sprite = card.artwork;
    }



}
