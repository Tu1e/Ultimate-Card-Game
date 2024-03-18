using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject oppDeck;
    public Transform oppDeckPos;
    void Start()
    {
        PhotonNetwork.Instantiate(oppDeck.name,oppDeckPos.position,Quaternion.identity);
    }
    void Update()
    {
        
    }
}
