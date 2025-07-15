using UnityEngine;

public class CardInteractionManager : MonoBehaviour
{
    [Header("Referências")]
    public BattleScript battleScript; // Para saber o estado do jogo
    public PlayerHand playerHand;     // Para poder remover a carta jogada da mão
    public Camera mainCamera;         // A câmera principal para o Raycast

    void Update()
    {
        // O gerenciador só "ouve" os cliques se o estado do jogo for o loop principal de gameplay
        // (ou seja, depois que todos já escolheram seus barcos).
        if (battleScript.gameState == GameState.GameplayLoop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleCardClick();
            }
        }
    }

    private void HandleCardClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Verifica se o objeto clicado tem o componente CardView
            CardView clickedCard = hit.collider.GetComponent<CardView>();

            // Garante que a carta clicada realmente pertence à mão do jogador
            if (clickedCard != null && playerHand.cartasNaMao.Contains(clickedCard))
            {
                Debug.Log($"<color=cyan>CLIQUE DETECTADO</color> na carta: {clickedCard.cardData.nomeDaCarta}");

                // Chama o método na própria carta para que ela possa, por exemplo, fazer uma animação.
                clickedCard.OnSelected();
                
                // ---- LÓGICA DO JOGO ----
                // Aqui é onde a mágica acontece. Dizemos ao jogo o que fazer com a carta.
                PlayCard(clickedCard);
            }
        }
    }

    private void PlayCard(CardView cardToPlay)
    {
        // TODO: Adicionar a lógica de jogo aqui.
        // Exemplo: Mover o barco correspondente usando o cardData.
        // BoatManager.Instance.MoveBoat(cardToPlay.cardData.idDoBarco, cardToPlay.cardData.valorMovimento);

        Debug.Log($"Jogando a carta para mover o barco ID {cardToPlay.cardData.idDoBarco} em {cardToPlay.cardData.valorMovimento} casas.");

        // Remove a carta da mão do jogador após ser jogada.
        playerHand.RemoverCartaDaMao(cardToPlay);
    }
}