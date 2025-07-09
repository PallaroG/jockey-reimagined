using UnityEngine;

public class CardPlayRecord
{
    public Player player;
    public Card card;
    public Boat boat;
    public int turnNumber;

    public CardPlayRecord(Player player, Card card, Boat boat, int turnNumber)
    {
        this.player = player;
        this.card = card;
        this.boat = boat;
        this.turnNumber = turnNumber;
    }
}