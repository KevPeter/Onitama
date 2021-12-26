using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControllerTest : MonoBehaviour
{
    public DisplayCardTest card;
    public GameObject controller;
    public GameObject pawn;
    public List<Vector2> cardMoves;


    public void OnMouseUp()
    {
        // get the pawn that was last clicked
        pawn = GameObject.FindGameObjectWithTag("clickedPawn");
        this.tag = "clickedCard";

        pawn.GetComponent<Pawns>().DestroyMovePlates();

        // pass in moves points to plates
        card = GetComponent<DisplayCardTest>();
        cardMoves = card.moves;


        pawn.GetComponent<Pawns>().InitiateMovePlates(cardMoves);


    }

}
