using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
public class SS_UI : MonoBehaviour
{//Start Screen UI
    [SerializeField] GameObject dmPanel,mainPanel;
    [SerializeField] TMP_InputField playerName;
    [SerializeField] Button playB;
    private void FixedUpdate()
    {
        if (playerName.text.Length > 0 && playerName.text != " ")
        {
            playB.interactable = true;
        }
        else
        {
            playB.interactable = false;
        }
    }
    public void LoadScene()
    {
        PhotonNetwork.NickName = playerName.text;
        SceneManager.LoadScene("Loading");
    }

    public void DeckManager()
    {
        mainPanel.SetActive(false);
        dmPanel.SetActive(true);
    }

    public void BackToMP()
    {
        mainPanel.SetActive(true);
        dmPanel.SetActive(false);
    }
}
