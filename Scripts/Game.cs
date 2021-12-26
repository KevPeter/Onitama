using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public GameObject pawn;
    public GameObject card;
    public Card cardTest;
    [SerializeField] Transform cardPosition;
    public GameObject endGameMenu;


    // positions and player's team for pawns
    private GameObject[,] positions = new GameObject[5, 5];
    private GameObject[] playerBlue = new GameObject[5];
    private GameObject[] playerRed = new GameObject[5];


    public GameObject[] playerBlueCards = new GameObject[2];
    public GameObject[] playerRedCards = new GameObject[2];
    public GameObject swapCard;


    public int[] cardIds = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31 };

    // change to be randomly chosen ( should display at start of game or possibly during the whole game)
    private string currentPlayer = "red";

    private bool gameOver = false;




    private void Awake()
    {
        // assign cards by generating random numbers from 0 - 31

        //randomly generate 5 unique numbers from 0-31 for the cards
        for (int i = 0; i < 5; i++)
        {
            int temp = cardIds[i];
            int randomIndex = Random.Range(i, 31);
            cardIds[i] = cardIds[randomIndex];
            cardIds[randomIndex] = temp;
        }

        // assign the ids to cards 
        card = playerBlueCards[0];
        card.GetComponent<DisplayCardTest>().displayId = cardIds[0];

        card = playerBlueCards[1];
        card.GetComponent<DisplayCardTest>().displayId = cardIds[1];

        card = playerRedCards[0];
        card.GetComponent<DisplayCardTest>().displayId = cardIds[2];

        card = playerRedCards[1];
        card.GetComponent<DisplayCardTest>().displayId = cardIds[3];

        card = swapCard;
        card.GetComponent<DisplayCardTest>().displayId = cardIds[4];


    }
    // Start is called before the first frame update
    void Start()
    {
        PickStartPlayer();


        playerRed = new GameObject[]
        {
            Create("redStudent", 0, 0), Create("redStudent", 1, 0), Create("redMaster", 2, 0), Create("redStudent", 3, 0), Create("redStudent", 4, 0)
        };

        playerBlue = new GameObject[]
        {
            Create("blueStudent", 0, 4), Create("blueStudent", 1, 4), Create("blueMaster", 2, 4), Create("blueStudent", 3, 4), Create("blueStudent", 4, 4)
        };

        // set positions for all the pawns
        for (int i = 0; i < playerRed.Length; i++)
        {
            SetPosition(playerRed[i]);
            SetPosition(playerBlue[i]);
        }

        GameObject.FindGameObjectWithTag("CurrentPlayerText").GetComponent<Text>().text = "Player Turn: <color=" + currentPlayer + ">" + currentPlayer.ToUpper() + "</color>";

    }

    public void PickStartPlayer()
    {
        int randomNum;
        randomNum = Random.Range(0, 2);
        if (randomNum == 0)
        {
            currentPlayer = "blue";
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(pawn, new Vector3(0, 0, -1), Quaternion.identity);
        Pawns currPawn = obj.GetComponent<Pawns>();
        currPawn.name = name;
        currPawn.SetXBoard(x);
        currPawn.SetYBoard(y);
        currPawn.Activate();
        return obj;
    }

    //function to set positions of the pawns
    public void SetPosition(GameObject obj)
    {
        Pawns currPawn = obj.GetComponent<Pawns>();

        positions[currPawn.GetXBoard(), currPawn.GetYBoard()] = obj;
    }


    //funtion to set the position  we are cuurrently at to empty when we move the pawn from that position
    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    //function to return a gameobject current position
    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    // function to check if it is a valid position on board
    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    //returns whose turn it current is
    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    // returns true if we reached a game over state
    public bool IsGameOver()
    {
        return gameOver;
    }

    //changes turn to the opposite player
    public void NextTurn()
    {
        if (currentPlayer == "red")
        {
            currentPlayer = "blue";
        }
        else
        {
            currentPlayer = "red";
        }
        GameObject.FindGameObjectWithTag("CurrentPlayerText").GetComponent<Text>().text = "Player Turn: <color=" + currentPlayer + ">" + currentPlayer.ToUpper() + "</color>";
    }

    public void Update()
    {

        /* checks if game is over and restarts game *** change to something else ***
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            SceneManager.LoadScene("Test");
        } */
    }

    public void Winner(string playerWinner)
    {
        gameOver = true;

        GameObject.FindGameObjectWithTag("CurrentPlayerText").GetComponent<Text>().enabled = false;

        endGameMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = "<color=" + playerWinner + ">" + playerWinner.ToUpper() + "</color>" + " WINS!";


    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("Menu");
    }

}