using UnityEngine;

public class BoatController : MonoBehaviour
{
    [Tooltip("Este ID é atribuído automaticamente. Não mude manualmente.")]
    public int boatID;

    public void MoveForward(int steps)
    {
        Debug.Log($"Movendo Barco ID {boatID} em {steps} casas.");
        // Coloque aqui sua lógica para mover o barco no tabuleiro (grid).
    }
}