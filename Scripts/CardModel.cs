using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardModel
{
    public int idNum;
    public Sprite artwork;
    public List<Vector2> moves;
    public string player;
    public string name;

    public CardModel(int idNum)
    {
        Card cardEntity = Resources.Load<Card>("Card" + idNum);
        idNum = cardEntity.idNum;
        artwork = cardEntity.artwork;
        moves = cardEntity.moves;
        player = cardEntity.player;
        name = cardEntity.name;
        
    }
}