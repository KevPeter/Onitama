using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    public GameObject pawn;
    public GameObject card;
    public GameObject tempcard;
    public Color32 transparent = new Color32(255, 255, 255, 255);

    //reference back to pawn
    GameObject reference = null;

    //positions on board (not world positions)
    int matrixX;
    int matrixY;

    

    //check if it is an attack space or just move space (false == movement)
    public bool attack = false;

    public void Start()
    {
        if(attack)
        {
            //change color of moveplate if it is an attack space
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 1.0f, .9f);

        }
    }

    // when the moveplate is clicked
    public void OnMouseUp()
    {
        
        pawn = GameObject.FindGameObjectWithTag("clickedPawn");
        pawn.tag = "Untagged";

        controller = GameObject.FindGameObjectWithTag("GameController");

        

        

        // if there is a pawn on the space get pawn object and destroy it
        if (attack)
        {
            
            GameObject currPawn = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            // check if the destroyed object is a master pawn, ending the game
            if (currPawn.name == "redMaster")
            {
                controller.GetComponent<Game>().Winner("blue");
            }
            if (currPawn.name == "blueMaster")
            {
                controller.GetComponent<Game>().Winner("red");
            }

            Destroy(currPawn);

        }

        // set position where the pawn originally was to empty
        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Pawns>().GetXBoard(),
            reference.GetComponent<Pawns>().GetYBoard());

        // change the position and coordinates of the pawn we just moved
        reference.GetComponent<Pawns>().SetXBoard(matrixX);
        reference.GetComponent<Pawns>().SetYBoard(matrixY);
        reference.GetComponent<Pawns>().SetCoordinates();

        //check alternate win condition
        if (MasterReachedThrone(pawn))
        {
            Debug.Log("player reached throne");
            string turnPlayer = controller.GetComponent<Game>().GetCurrentPlayer();
            controller.GetComponent<Game>().Winner(turnPlayer);
        }

        controller.GetComponent<Game>().SetPosition(reference);

        //swap cards
        card = GameObject.FindGameObjectWithTag("clickedCard");
        if (controller.GetComponent<Game>().GetCurrentPlayer() == "red")
        {
            //disable box collider for red cards
            controller.GetComponent<Game>().playerRedCards[0].GetComponent<BoxCollider2D>().enabled = false;
            controller.GetComponent<Game>().playerRedCards[1].GetComponent<BoxCollider2D>().enabled = false;

            // turn card to normal transparency
            controller.GetComponent<Game>().playerBlueCards[0].GetComponent<Image>().color = transparent;
            controller.GetComponent<Game>().playerBlueCards[1].GetComponent<Image>().color = transparent;
            controller.GetComponent<Game>().swapCard.GetComponent<Image>().color = transparent;

            for (int i = 0; i < 2; i++)
            {
                if (controller.GetComponent<Game>().playerRedCards[i] == card)
                {

                    //swap positions on board for swap card with playercard selected
                    Vector3 tempPosition = card.transform.position;
                    card.transform.position = controller.GetComponent<Game>().swapCard.transform.position;
                    controller.GetComponent<Game>().swapCard.transform.position = tempPosition;

                    Quaternion tempRotation = card.transform.rotation;
                    card.transform.rotation = controller.GetComponent<Game>().swapCard.transform.rotation;
                    controller.GetComponent<Game>().swapCard.transform.rotation = tempRotation;

                    //swap cards in swap card with playerCards array
                    tempcard = card;
                    controller.GetComponent<Game>().playerRedCards[i] = controller.GetComponent<Game>().swapCard;
                    controller.GetComponent<Game>().swapCard = tempcard;
                }


            }
        }
        else
        {
            //disable box collider for blue cards
            controller.GetComponent<Game>().playerBlueCards[0].GetComponent<BoxCollider2D>().enabled = true;
            controller.GetComponent<Game>().playerBlueCards[1].GetComponent<BoxCollider2D>().enabled = true;

            // turn card to normal transparency
            controller.GetComponent<Game>().playerRedCards[0].GetComponent<Image>().color = transparent;
            controller.GetComponent<Game>().playerRedCards[1].GetComponent<Image>().color = transparent;
            controller.GetComponent<Game>().swapCard.GetComponent<Image>().color = transparent;

            for (int i = 0; i < 2; i++)
            {
                if (controller.GetComponent<Game>().playerBlueCards[i] == card)
                {
                    //swap positions on board for swap card with playercard selected
                    Vector3 tempPosition = card.transform.position;
                    card.transform.position = controller.GetComponent<Game>().swapCard.transform.position;
                    controller.GetComponent<Game>().swapCard.transform.position = tempPosition;

                    Quaternion tempRotation = card.transform.rotation;
                    card.transform.rotation = controller.GetComponent<Game>().swapCard.transform.rotation;
                    controller.GetComponent<Game>().swapCard.transform.rotation = tempRotation;

                    //swap cards in swap card with playerCards array
                    tempcard = card;
                    controller.GetComponent<Game>().playerBlueCards[i] = controller.GetComponent<Game>().swapCard;
                    controller.GetComponent<Game>().swapCard = tempcard;
                }


            }

        }
        card.tag = "Untagged";

        // switch turns to other player
        controller.GetComponent<Game>().NextTurn();

        //take move plates off the board
        reference.GetComponent<Pawns>().DestroyMovePlates();


    }

    // set the coordinates for the move plates
    public void SetCoordinates(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    // make the object possible to be set as reference
    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    // make it possible for another object to get a reference of the moveplate
    public GameObject GetRefernce()
    {
        return reference;
    }

    public bool MasterReachedThrone(GameObject pawn)
    {


        return (pawn.name == "redMaster" && pawn.GetComponent<Pawns>().GetXBoard() == 2 && pawn.GetComponent<Pawns>().GetYBoard() == 4)
            || (pawn.name == "blueMaster" && pawn.GetComponent<Pawns>().GetXBoard() == 2 && pawn.GetComponent<Pawns>().GetYBoard() == 0);
    }

}
