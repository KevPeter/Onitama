using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabaseTest : MonoBehaviour
{
    public static List<CardTest> cardList = new List<CardTest>();

    private void Awake()
    {
        cardList.Add(new CardTest(0, "Bear", new List<Vector2>() { new Vector2(-1,1), new Vector2(0,1), new Vector2(1,-1) }, Resources.Load<Sprite>("images/move card bear1") ));

        cardList.Add(new CardTest(1, "Boar", new List<Vector2>() { new Vector2(-1,0), new Vector2(0,1), new Vector2(1,0) }, Resources.Load<Sprite>("images/move card boar1") ));

        cardList.Add(new CardTest(2, "Cobra", new List<Vector2>() { new Vector2(-1,0), new Vector2(1,1), new Vector2(1,-1) }, Resources.Load<Sprite>("images/move card cobra1") ));

        cardList.Add(new CardTest(3, "Crab", new List<Vector2>() { new Vector2(-2,0), new Vector2(0,1), new Vector2(2,0) }, Resources.Load<Sprite>("images/move card crab1")));

        cardList.Add(new CardTest(4, "Crane", new List<Vector2>() { new Vector2(-1,-1), new Vector2(0,1), new Vector2(1,-1) }, Resources.Load<Sprite>("images/move card crane1")));

        cardList.Add(new CardTest(5, "Dog", new List<Vector2>() { new Vector2(-1, 1), new Vector2(-1, 0), new Vector2(-1, -1) }, Resources.Load<Sprite>("images/move card dog1")));

        cardList.Add(new CardTest(6, "Dragon", new List<Vector2>() { new Vector2(-2, 1), new Vector2(-1, -1), new Vector2(1, -1), new Vector2(2,1) }, Resources.Load<Sprite>("images/move card dragon1")));

        cardList.Add(new CardTest(7, "Eel", new List<Vector2>() { new Vector2(-1, 1), new Vector2(-1, -1), new Vector2(1, 0) }, Resources.Load<Sprite>("images/move card eel1")));

        cardList.Add(new CardTest(8, "Elephant", new List<Vector2>() { new Vector2(-1, 1), new Vector2(-1, 0), new Vector2(1, 1), new Vector2(1,0) }, Resources.Load<Sprite>("images/move card elephant1")));

        cardList.Add(new CardTest(9, "Fox", new List<Vector2>() { new Vector2(1, 1), new Vector2(1, 0), new Vector2(1, -1) }, Resources.Load<Sprite>("images/move card fox1")));

        cardList.Add(new CardTest(10, "Frog", new List<Vector2>() { new Vector2(-2, 0), new Vector2(-1, 1), new Vector2(1, -1) }, Resources.Load<Sprite>("images/move card frog1")));

        cardList.Add(new CardTest(11, "Giraffe", new List<Vector2>() { new Vector2(-2, 1), new Vector2(0, -1), new Vector2(2, 1) }, Resources.Load<Sprite>("images/move card giraffe1")));

        cardList.Add(new CardTest(12, "Goose", new List<Vector2>() { new Vector2(-1, 1), new Vector2(-1, 0), new Vector2(1, 0), new Vector2(1, -1) }, Resources.Load<Sprite>("images/move card goose1")));

        cardList.Add(new CardTest(13, "Horse", new List<Vector2>() { new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) }, Resources.Load<Sprite>("images/move card horse1")));

        cardList.Add(new CardTest(14, "Iguana", new List<Vector2>() { new Vector2(-2, 1), new Vector2(0, 1), new Vector2(1, -1) }, Resources.Load<Sprite>("images/move card iguana1")));

        cardList.Add(new CardTest(15, "Kirin", new List<Vector2>() { new Vector2(-1, 2), new Vector2(1, 2), new Vector2(0, -2) }, Resources.Load<Sprite>("images/move card kirin1")));

        cardList.Add(new CardTest(16, "Mantis", new List<Vector2>() { new Vector2(-1, 1), new Vector2(0, -1), new Vector2(1, 1) }, Resources.Load<Sprite>("images/move card mantis1")));

        cardList.Add(new CardTest(17, "Monkey", new List<Vector2>() { new Vector2(-1, 1), new Vector2(-1, -1), new Vector2(1, 1), new Vector2(1,-1) }, Resources.Load<Sprite>("images/move card monkey1")));

        cardList.Add(new CardTest(18, "Mouse", new List<Vector2>() { new Vector2(-1, -1), new Vector2(0, 1), new Vector2(1, 0) }, Resources.Load<Sprite>("images/move card mouse1")));

        cardList.Add(new CardTest(19, "Otter", new List<Vector2>() { new Vector2(-1, 1), new Vector2(1, -1), new Vector2(2, 0) }, Resources.Load<Sprite>("images/move card otter1")));

        cardList.Add(new CardTest(20, "Ox", new List<Vector2>() { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0) }, Resources.Load<Sprite>("images/move card ox1")));

        cardList.Add(new CardTest(21, "Panda", new List<Vector2>() { new Vector2(-1, -1), new Vector2(0, 1), new Vector2(1, 1) }, Resources.Load<Sprite>("images/move card panda1")));

        cardList.Add(new CardTest(22, "Phoenix", new List<Vector2>() { new Vector2(-2, 0), new Vector2(-1, 1), new Vector2(1, 1), new Vector2(2,0) }, Resources.Load<Sprite>("images/move card phoenix1")));

        cardList.Add(new CardTest(23, "Rabbit", new List<Vector2>() { new Vector2(-1, -1), new Vector2(1, 1), new Vector2(2, 0) }, Resources.Load<Sprite>("images/move card rabbit1")));

        cardList.Add(new CardTest(24, "Rat", new List<Vector2>() { new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, -1) }, Resources.Load<Sprite>("images/move card rat1")));

        cardList.Add(new CardTest(25, "Rooster", new List<Vector2>() { new Vector2(-1, 0), new Vector2(-1, -1), new Vector2(1, 0), new Vector2(1,1)}, Resources.Load<Sprite>("images/move card rooster1")));

        cardList.Add(new CardTest(26, "Sable", new List<Vector2>() { new Vector2(-2, 0), new Vector2(-1, -1), new Vector2(1, 1) }, Resources.Load<Sprite>("images/move card sable1")));

        cardList.Add(new CardTest(27, "Sea Snake", new List<Vector2>() { new Vector2(-1, -1), new Vector2(0, 1), new Vector2(2, 0) }, Resources.Load<Sprite>("images/move card sea snake1")));

        cardList.Add(new CardTest(28, "Tanuki", new List<Vector2>() { new Vector2(-1, -1), new Vector2(0, 1), new Vector2(2,1) }, Resources.Load<Sprite>("images/move card tanuki1")));

        cardList.Add(new CardTest(29, "Tiger", new List<Vector2>() { new Vector2(0, 2), new Vector2(0, -1)}, Resources.Load<Sprite>("images/move card tiger1")));

        cardList.Add(new CardTest(30, "Turtle", new List<Vector2>() { new Vector2(-2, 0), new Vector2(-1, -1), new Vector2(1, -1), new Vector2(2,0) }, Resources.Load<Sprite>("images/move card turtle1")));

        cardList.Add(new CardTest(31, "Viper", new List<Vector2>() { new Vector2(-2, 0), new Vector2(0, 1), new Vector2(1, -1) }, Resources.Load<Sprite>("images/move card viper1")));
    }
}
