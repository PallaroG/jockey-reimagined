using UnityEngine;
using UnityEngine.InputSystem;  // 1) importe o novo namespace

public class BoatSelectionManager : MonoBehaviour
{
    private GameObject selectedBoat = null;

    void Update()
    {
        // Se já tiver selecionado, não processa mais cliques
        if (selectedBoat != null)
            return;

        // 2) checa clique com o novo sistema
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Barco"))
                {
                    selectedBoat = hit.collider.gameObject;
                    Debug.Log($"Barco selecionado: {selectedBoat.name}");

                    // desabilita os colliders dos outros barcos
                    foreach (var boat in GameObject.FindGameObjectsWithTag("Barco"))
                        if (boat != selectedBoat)
                            if (boat.TryGetComponent<Collider>(out var col))
                                col.enabled = false;
                }
            }
        }
    }
}