using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_data", menuName = "Cards/Card_data", order = 1)]
public class Card_data : ScriptableObject
{
//    public string card_name;
//    public string description;
//    public int health;
//    public int cost;
//    public int damage;
//    public Sprite sprite;

    public int suit; // Spades are 1, hearts are 2, diamonds are 3, clubs are 4, no jokers.
    public int type;// 0 is a normal card, 1 is a jack, 2 is a queen, 3 is a king, 4 is an ace. This is used by the script.
    public string symbol; // Represents symbol for sprite, jack is J, queen is Q, king is K, ace is A.
}
