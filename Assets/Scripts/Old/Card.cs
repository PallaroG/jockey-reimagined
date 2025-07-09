using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
	public string cardName;
	public Sprite artwork;
	public string description;
	public CardEffectType effectType;
	public int movementRange;
	public CardColor cardColor;

	
}

public enum CardColor
{
	Blue,       //0
	Red,        //1
	Purple,     //2
	Orange,     //3
	Yellow,     //4
	Green,      //5
	Gray        //6
}
public enum CardEffectType
{
	MoveForwards,   //0
	MoveBackwards   //1
					// Add more effect types as needed
}

