using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardType;
    public string cardName = "Name";
    public int Id = 0;
    public string description;
    public Sprite artwork;
    public int lvl;
    public int atk;
    public int def;
    private static int nextID = 1;

    private void OnEnable()
    {
        Id = nextID;
        nextID++;
        name = cardName;
    }
}

