using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class CardTest
{
    public int id;
    public string cardName;
    public List<Vector2> moves;
    public Sprite spriteImage;

    public CardTest()
    {

    }

    public CardTest(int Id, string CardName, List<Vector2> Moves, Sprite SpriteImage)
    {
        id = Id;
        cardName = CardName;
        moves = Moves;
        spriteImage = SpriteImage;
        

    }
}
