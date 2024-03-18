using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public Button createB, joinB;
    public GameObject lobbyPanel, roomPanel;
    public TextMeshProUGUI rName;

    private void FixedUpdate()
    {
        if(createInput.text.Length > 0 && createInput.text != " ")
        {
            createB.interactable = true;
        }
        else
        {
            createB.interactable = false;
        }

        if (joinInput.text.Length > 0 && joinInput.text != " ")
        {
            joinB.interactable = true;
        }
        else
        {
            joinB.interactable = false;
        }

    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions { MaxPlayers = 2 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        SwitchPanels();
        rName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        /*if ()
        {*/
            PhotonNetwork.LoadLevel("Battle");
      //  }
        
    }

    void SwitchPanels()
    {
        lobbyPanel.SetActive(!lobbyPanel.active);
        roomPanel.SetActive(!roomPanel.active);
    }
}
