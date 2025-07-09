using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public string playerName;
    public List<CardInstance> hand = new List<CardInstance>();
    public List<Boat> characters = new List<Boat>();

    public Player(string name)
    {
        playerName = name;
    }

    public CardInstance SelectCard()
    {
        // Placeholder: Always selects the first card
        return hand[0];
    }

    public Boat SelectBoat()
    {
        // Placeholder: Always selects the first character
        return characters[0];
    }

    public object SelectCardAndCharacter()
    {
        return 0;
    }

    public void OnCardClicked(Card card)
    {
        /*if (IsMyTurn)
        {
            TurnManager.SubmitCard(this, card, selectedCharacter);
        }*/
    }
}