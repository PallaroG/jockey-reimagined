using UnityEngine;

public class GridNode
{
    public Vector2Int position;
    public bool isWalkable;
    public Boat occupiedBoat; // Null if empty
}