using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public GameObject controller;

    private int xBoard = -1;
    private int yBoard = -1;

    public Sprite artwork;
    //public List<CardMove> moveset;  // remove if vector2 works 
    public List<Vector2> moves;
    public int idNum;
    public string player;

    
    public Card GetInstance()
    {
        return Instantiate(this);
    }
    

    public void Activate()
    {
        // get access to controller
        controller = GameObject.FindGameObjectWithTag("GameController");

        // put pawn in correct location on board
        SetCoordinates();

        //get correct sprite images for each pawn object
        
    }

    public void SetCoordinates()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 15f;
        y *= 15f;

        x += -30.5f;
        y += -30.5f;

        //this.transform.position = new Vector3(x, y, -1.0f);
    }

    // setter and getters for cards .. may make public 
    public int GetXBoard()
    {
        return xBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

}
