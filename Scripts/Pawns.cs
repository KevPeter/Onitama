using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawns : MonoBehaviour
{
    // references
    public GameObject controller;
    public GameObject movePlate;
    public CardControllerTest cardControl;
    public GameObject pawn;
    public GameObject card;
    
    Color32 transparent = new Color32(255, 255, 255, 100);
    

    public GameObject[] blueCards;
    public GameObject[] redCards;

    //positions , may make public and get rid of getters/setters.
    private int xBoard = -1;
    private int yBoard = -1;

    //variable to keep track of red or blue player
    private string player;

    // references for pawn sprites
    public Sprite redStudent, redMaster;
    public Sprite blueStudent, blueMaster;


    public void Activate()
    {
        // get access to controller
        controller = GameObject.FindGameObjectWithTag("GameController");

        // put pawn in correct location on board
        SetCoordinates();

        //get correct sprite images for each pawn object
        switch (this.name)
        {
            case "redStudent": this.GetComponent<SpriteRenderer>().sprite = redStudent; player = "red"; break;
            case "redMaster": this.GetComponent<SpriteRenderer>().sprite = redMaster; player = "red";  break;

            case "blueStudent": this.GetComponent<SpriteRenderer>().sprite = blueStudent; player = "blue"; break;
            case "blueMaster": this.GetComponent<SpriteRenderer>().sprite = blueMaster; player = "blue"; break;

            
        }
    }

    // put pawn in correct location on board
    public void SetCoordinates()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 18f;
        y *= 18f;

        x += -36.0f;
        y += -36.0f;
        

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    // setter and getters for pawns .. may make public 
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

    // when a moveplate is selected 
    private void OnMouseUp()
    {
        ResetBoard();
        

        // checks if the game isnt over or if the pawn we are trying to move belongs to the current player
        if (!controller.GetComponent<Game>().IsGameOver() &&
            controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            //enable box colliders for the current players cards
            if (controller.GetComponent<Game>().GetCurrentPlayer() == "red")
            {
                controller.GetComponent<Game>().playerRedCards[0].GetComponent<BoxCollider2D>().enabled = true;
                controller.GetComponent<Game>().playerRedCards[1].GetComponent<BoxCollider2D>().enabled = true;

                //lighten other cards
                controller.GetComponent<Game>().playerBlueCards[0].GetComponent<Image>().color = transparent;
                controller.GetComponent<Game>().playerBlueCards[1].GetComponent<Image>().color = transparent;
                controller.GetComponent<Game>().swapCard.GetComponent<Image>().color = transparent;


            }
            else if (controller.GetComponent<Game>().GetCurrentPlayer() == "blue")
            {
                //enable box colliders for the current players cards
                controller.GetComponent<Game>().playerBlueCards[0].GetComponent<BoxCollider2D>().enabled = true;
                controller.GetComponent<Game>().playerBlueCards[1].GetComponent<BoxCollider2D>().enabled = true;

                //lighten other cards
                controller.GetComponent<Game>().playerRedCards[0].GetComponent<Image>().color = transparent;
                controller.GetComponent<Game>().playerRedCards[1].GetComponent<Image>().color = transparent;
                controller.GetComponent<Game>().swapCard.GetComponent<Image>().color = transparent;
            }
            this.tag = "clickedPawn";
            
            //DestroyMovePlates();

            //InitiateMovePlates();
            
            
        }
    }

    public void ResetBoard()
    {
        // clear any previously clicked pawn
        if (GameObject.FindGameObjectWithTag("clickedPawn"))
        {
            pawn = GameObject.FindGameObjectWithTag("clickedPawn");
            pawn.tag = "Untagged";
        }

        DestroyMovePlates();

        //clear previously clicked card
        if (GameObject.FindGameObjectWithTag("clickedCard"))
        {
            card = GameObject.FindGameObjectWithTag("clickedCard");
            card.tag = "Untagged";
        }

        //set cards to be unclickable again
        controller.GetComponent<Game>().playerBlueCards[0].GetComponent<BoxCollider2D>().enabled = false;
        controller.GetComponent<Game>().playerBlueCards[1].GetComponent<BoxCollider2D>().enabled = false;

        controller.GetComponent<Game>().playerRedCards[0].GetComponent<BoxCollider2D>().enabled = false;
        controller.GetComponent<Game>().playerRedCards[1].GetComponent<BoxCollider2D>().enabled = false;

        controller.GetComponent<Game>().swapCard.GetComponent<BoxCollider2D>().enabled = false;
        

    }
    
    // get rid of all the move plates on the board
    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i ++)
        {
            Destroy(movePlates[i]);
        }
    }

    // get move plates coordinates equal to card moveset ***change to correct card values***

    // create move plate coordinates relative to where the pawn is *** change for card values**
    public void InitiateMovePlates(List<Vector2> cardMoves)
    {
        // check if it is blue or red players card( the squares need to be flipped 180 if blue
        int rotation;
        if (controller.GetComponent<Game>().GetCurrentPlayer() == "red")
        {
            rotation = 1;
        }
        else
        {
            rotation = -1;
        }

        // to change to cards:
        // for each move in moves (PointMovePlate(xBoard + move.x, yBoard + move.y)
        for (int i = 0; i < cardMoves.Count; i++)
        {
            PointMovePlate(xBoard + (int)cardMoves[i].x * rotation, yBoard + (int)cardMoves[i].y * rotation);
            
            
        }
    }

    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();

        if(sc.PositionOnBoard(x, y))
        {
            GameObject currPawn = sc.GetPosition(x, y);
            // if there isnt a pawn in this position already
            if (currPawn == null)
            {
                MovePlateSpawn(x, y);
            }
            // if there is an opposing pawn there
            else if(currPawn.GetComponent<Pawns>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }

        }
    }

    // put the regular move plate on the board
    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 18f;
        y *= 18f;

        x += -36f;
        y += -36f;

        GameObject currMovePlate = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate currMovePlateScript = currMovePlate.GetComponent<MovePlate>();
        currMovePlateScript.SetReference(gameObject);
        currMovePlateScript.SetCoordinates(matrixX, matrixY);

    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 18f;
        y *= 18f;

        x += -36f;
        y += -36f;

        GameObject currMovePlate = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate currMovePlateScript = currMovePlate.GetComponent<MovePlate>();
        currMovePlateScript.attack = true;
        currMovePlateScript.SetReference(gameObject);
        currMovePlateScript.SetCoordinates(matrixX, matrixY);

    }

   
}
