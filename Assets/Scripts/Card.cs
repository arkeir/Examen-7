using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;

    public Sprite artwork;

    public int cardID;
    public int attackPower;
    public int defensePower;
    public int value;


    public void Print()
    {
    }
}