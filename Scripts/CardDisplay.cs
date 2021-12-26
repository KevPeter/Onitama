using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Image artworkImage;

    /*
    public void Show(CardModel cardModel) // cardModel
    {
        artworkImage.sprite = cardModel.artwork;
    }
    */

    
    // Start is called before the first frame update 
    void Start()
    {
        //artworkImage.sprite = card.artwork;
        LoadCard(card);
        
    }
    public void LoadCard(Card c)
    {
        card = c;
        artworkImage.sprite = c.artwork;

    }

    
}
