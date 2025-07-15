using UnityEngine;
using UnityEngine.UI;

public enum GameState { Start, PlayerChooseBoat, IaChooseBoat, GameplayLoop }

public class BattleScript : MonoBehaviour
{
    [Header("Controle de Estado")]
    public GameState gameState;
    public int numeroDeIAs = 5;

    [Header("Referências de UI")]
    public GameObject jogarButton;
    public GameObject passarTurnoButton;
    public GameObject mensagemUI;

    [Header("Referências de Scripts")]
    public BoatSelectionManager selectionManager;
    public PlayerHand playerHand;

    void Start()
    {
        gameState = GameState.Start;
        jogarButton.SetActive(true);
        passarTurnoButton.SetActive(false);
        if (mensagemUI != null) mensagemUI.SetActive(false);
        
        // Mantemos o objeto da mão desativado se ele existir,
        // já que o teste é só no console.
        if (playerHand != null) playerHand.gameObject.SetActive(false);
    }

    public void OnJogarButtonClicked()
    {
        jogarButton.SetActive(false);
        if (mensagemUI != null) mensagemUI.SetActive(true);
        gameState = GameState.PlayerChooseBoat;
    }

    public void OnPassarTurnoButtonClicked()
    {
        passarTurnoButton.SetActive(false);
        gameState = GameState.IaChooseBoat;
        selectionManager.SelectBoatsForIA(numeroDeIAs);

        gameState = GameState.GameplayLoop;
        
        // Chamada para o teste de compra de cartas
        if (playerHand != null)
        {
            // Ativamos o objeto SÓ para garantir que o script PlayerHand possa rodar
            playerHand.gameObject.SetActive(true);

            // Chamamos a compra de cartas, que agora só vai usar o console
            playerHand.ComprarCartasIniciais(7);

            // Desativamos de novo, pois não há nada para ver
            playerHand.gameObject.SetActive(false); 
        }
        else
        {
            Debug.LogError("ERRO: A referência ao PlayerHand não está configurada no BattleScript!");
        }
    }

    public void PlayerHasChosenBoat()
    {
        passarTurnoButton.SetActive(true);
        if (mensagemUI != null) mensagemUI.SetActive(false);
    }
}