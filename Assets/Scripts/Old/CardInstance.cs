using UnityEngine;

public class CardInstance
{
    public Card cardData;
    public Player owner;

    public CardInstance(Card cardData, Player owner)
    {
        this.cardData = cardData;
        this.owner = owner;
    }
}