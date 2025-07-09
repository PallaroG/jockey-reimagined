using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public string tileTag = "Tile";

    void Start()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag(tileTag);

        Debug.Log($"Desativados {tiles.Length} tiles com a tag '{tileTag}'.");
    }
}
