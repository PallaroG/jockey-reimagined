using System.Collections.Generic;
using UnityEngine;

public class BoatSelectionManager : MonoBehaviour
{
    [Header("Configuração Central")]
    [Tooltip("Arraste os 6 GameObjects de barco da sua cena para esta lista. A ORDEM AQUI DEFINE O ID.")]
    public List<BoatController> todosOsBarcos;

    [Header("Referências")]
    public BattleScript battleScript;
    public Camera mainCamera;

    // Gerenciamento Interno
    private List<BoatController> barcosDisponiveis;
    public BoatController barcoEscolhidoPeloJogador { get; private set; }
    public Dictionary<int, BoatController> barcosEscolhidosPelaIA { get; private set; } = new Dictionary<int, BoatController>();

    void Awake()
    {
        for (int i = 0; i < todosOsBarcos.Count; i++)
        {
            if (todosOsBarcos[i] != null) todosOsBarcos[i].boatID = i;
        }
        barcosDisponiveis = new List<BoatController>(todosOsBarcos);
    }

    void Update()
    {
        // A detecção de clique só funciona se o BattleScript disser que é a hora certa.
        if (battleScript.gameState == GameState.PlayerChooseBoat)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleBoatSelectionClick();
            }
        }
    }

    private void HandleBoatSelectionClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            BoatController barcoClicado = hit.collider.GetComponent<BoatController>();
            if (barcoClicado != null && barcosDisponiveis.Contains(barcoClicado))
            {
                // Registra a escolha do jogador
                barcoEscolhidoPeloJogador = barcoClicado;
                barcosDisponiveis.Remove(barcoClicado);
                Debug.Log($"<color=green>JOGADOR escolheu o Barco ID: {barcoEscolhidoPeloJogador.boatID}</color>");

                // AVISA o BattleScript que a escolha foi feita, para que ele possa mostrar o botão "Passar Turno"
                battleScript.PlayerHasChosenBoat();
            }
        }
    }

    // Este método é chamado pelo BattleScript para que as IAs façam suas escolhas.
    public void SelectBoatsForIA(int numberOfIAs)
    {
        for (int i = 0; i < numberOfIAs; i++)
        {
            if (barcosDisponiveis.Count > 0)
            {
                int randomIndex = Random.Range(0, barcosDisponiveis.Count);
                BoatController barcoDaIA = barcosDisponiveis[randomIndex];
                barcosEscolhidosPelaIA.Add(i, barcoDaIA);
                barcosDisponiveis.RemoveAt(randomIndex);
                Debug.Log($"<color=red>IA {i} escolheu o Barco ID: {barcoDaIA.boatID}</color>");
            }
        }
    }
}