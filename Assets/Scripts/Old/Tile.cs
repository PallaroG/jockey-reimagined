using UnityEngine;

public class Tile
{
    public Vector2Int position;
    public Boat occupant;

    public Tile(int x, int y)
    {
        position = new Vector2Int(x, y);
        occupant = null;
    }

    public bool IsOccupied()
    {
        return occupant != null;
    }
}
