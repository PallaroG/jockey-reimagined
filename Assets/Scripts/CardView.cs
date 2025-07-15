using UnityEngine;

public class CardView : MonoBehaviour // Não precisa mais de IPointerClickHandler
{
    [Header("Dados da Carta")]
    public CardData cardData;

    [Header("Referências 3D do Prefab")]
    [Tooltip("O MeshRenderer da parte da carta que mostra a arte.")]
    public MeshRenderer artworkRenderer; // Em vez de Image

    [Tooltip("O componente TextMesh para o nome (texto 3D).")]
    public TextMesh nameText; // Em vez de TextMeshProUGUI

    [Tooltip("O componente TextMesh para o movimento (texto 3D).")]
    public TextMesh movementText;

    // O método Setup continua com a mesma função
    public void Setup(CardData data)
    {
        cardData = data;

        // Para a arte, em vez de mudar o sprite, mudamos o material ou a textura do MeshRenderer.
        // Isso depende de como seu modelo 3D foi feito. O mais comum é mudar a textura principal.
        if (cardData.arteDaCarta != null)
        {
            artworkRenderer.material.mainTexture = cardData.arteDaCarta.texture;
        }

        // Atualiza os textos 3D
        if (nameText != null) nameText.text = cardData.nomeDaCarta;
        if (movementText != null) movementText.text = cardData.valorMovimento.ToString();
    }

        
    public void OnSelected()
    {
        // Por exemplo, fazer a carta pular ou brilhar.
        Debug.Log($"O método OnSelected() foi chamado na carta {cardData.nomeDaCarta}.");
    
        // A lógica principal do jogo (mover barco, etc) é feita no CardInteractionManager.
    }
}