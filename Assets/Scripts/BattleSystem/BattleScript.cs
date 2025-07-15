using UnityEngine;
using UnityEngine.UI; // Necessário para interagir com botões

// O enum foi melhorado para refletir os estados de seleção de forma mais clara
public enum GameState { Start, PlayerChooseBoat, IaChooseBoat, GameplayLoop }

public class BattleScript : MonoBehaviour
{
    [Header("Controle de Estado")]
    public GameState gameState;
    public int numeroDeIAs = 5;

    [Header("Referências de UI")]
    public GameObject jogarButton;
    public GameObject passarTurnoButton;
    public GameObject mensagemUI; // Opcional, para dar feedback ao jogador

    [Header("Referências de Scripts")]
    public BoatSelectionManager selectionManager;

    void Start()
    {
        // Estado inicial do jogo
        gameState = GameState.Start;

        // Configuração inicial dos botões
        jogarButton.SetActive(true);
        passarTurnoButton.SetActive(false);
        mensagemUI.SetActive(false); // Esconde a mensagem inicial
    }

    // --- MÉTODOS CONTROLADOS PELOS BOTÕES ---

    // Este método deve ser chamado pelo OnClick() do seu botão "Jogar"
    public void OnJogarButtonClicked()
    {
        jogarButton.SetActive(false); // Esconde o botão "Jogar"
        mensagemUI.SetActive(true);   // Mostra uma mensagem como "Escolha seu barco"
        // (Você precisa configurar o texto da mensagem na UI)

        // Muda o estado para permitir que o jogador escolha um barco
        gameState = GameState.PlayerChooseBoat;
        Debug.Log("Estado alterado para PlayerChooseBoat. Clique em um barco.");
    }

    // Este método deve ser chamado pelo OnClick() do seu botão "Passar Turno"
    public void OnPassarTurnoButtonClicked()
    {
        passarTurnoButton.SetActive(false); // Esconde o botão após o clique

        // Muda o estado e inicia a seleção das IAs
        gameState = GameState.IaChooseBoat;
        Debug.Log("Estado alterado para IaChooseBoat. IAs estão escolhendo...");
        selectionManager.SelectBoatsForIA(numeroDeIAs);

        // Após a seleção da IA, o jogo entra no loop principal
        gameState = GameState.GameplayLoop;
        Debug.Log("Seleção completa! O jogo agora entraria no loop de movimento de cartas.");
    }


    // --- MÉTODO DE COMUNICAÇÃO ---

    // Este método é CHAMADO pelo BoatSelectionManager quando o jogador clica em um barco válido.
    public void PlayerHasChosenBoat()
    {
        Debug.Log("BattleScript notificado: Jogador escolheu um barco.");
        // Agora que o jogador escolheu, o botão "Passar Turno" aparece.
        passarTurnoButton.SetActive(true);
        mensagemUI.SetActive(false); // Esconde a mensagem "Escolha seu barco"
    }
}