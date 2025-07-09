using UnityEngine;

public class Boat
{
    public string boatColor;
    public Player owner;
    public Vector2Int position;

    public Boat(string boatColor, Player owner, Vector2Int startPos)
    {
        this.boatColor = boatColor;
        this.owner = owner;
        this.position = startPos;
    }

    public void MoveTo(Vector2Int newPosition)
    {
        position = newPosition;
    }
}
