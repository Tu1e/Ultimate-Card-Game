using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/*
   Drawing, who can play at the moment
 */
public class TurnManager : MonoBehaviourPunCallbacks
{
    Deck[] decks;
    int faze;//0 - master play, 1 - master activate cards, 2 - master attack ; 3 - nonMaster play, 4 - nonMaster activate cards, 5 - nonMaster attack 
    int playerCoef = 0;
    //PhotonNetwork.MasterClient
    void Start()
    {
        decks = new Deck[2];//Must be changed for adding spectators
        decks = GetComponents<Deck>();
        if (PhotonNetwork.IsMasterClient)
        {
            playerCoef = 3;
            PhotonView photonView = GetComponent<PhotonView>();

            photonView.RPC("WhoStarts", RpcTarget.All);
        }
        else
        {
            Debug.Log("PhotonView component not found in object: " + name);
        }

        
    }

    [PunRPC]
    void WhoStarts()
    {
        if(Random.value <= 0.5)
        {
            foreach(Deck deck in decks)
            {
                if (deck.isMaster)
                {
                    deck.Draw();
                }
            }
            faze = 0;
            return;
        }

        foreach (Deck deck in decks)
        {
            if (!deck.isMaster)
            {
                deck.Draw();
            }
        }

        faze = 3;
        //Not master
    }

    public void NextFaze()//changing faze on button
    {
        faze++;
        if(faze >= 6)
        {
            faze = 0;
        }
    }

    
}
