using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DisplayCardTest : MonoBehaviour
{
    public List<CardTest> displayCard = new List<CardTest>();
    public int displayId;

    public int id;
    public string cardName;
    public List<Vector2> moves;
    public Sprite spriteImage;

    public Image artImage;

    // Start is called before the first frame update
    void Start()
    {
        displayCard[0] = CardDatabaseTest.cardList[displayId];
        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        moves = displayCard[0].moves;
        spriteImage = displayCard[0].spriteImage;

        artImage.sprite = spriteImage;
    }

    // Update is called once per frame
    void Update()
    {



    }
}
