using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [Header("Referências")]
    [Tooltip("Arraste o seu PREFAB 3D de carta mestre aqui.")]
    public GameObject cardPrefab; 

    [Header("Configuração de Layout 3D")]
    [Tooltip("O espaçamento entre cada carta na mão.")]
    public float cardSpacing = 1.2f; // Ajuste este valor para o seu modelo

    public List<CardView> cartasNaMao = new List<CardView>();

    public void ComprarCartasIniciais(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            ComprarUmaCarta();
        }
    }

    public void ComprarUmaCarta()
    {
        CardData novaCartaData = CardManager.Instance.ComprarCarta();
        if (novaCartaData != null)
        {
            // Instancia o prefab de carta 3D como filho deste objeto
            GameObject novaCartaObjeto = Instantiate(cardPrefab, this.transform);

            // Configura a carta com os dados
            CardView cardView = novaCartaObjeto.GetComponent<CardView>();
            cardView.Setup(novaCartaData);

            cartasNaMao.Add(cardView);

            // Atualiza a posição de todas as cartas na mão
            AtualizarLayoutMao();
        }
    }

    // Este método organiza as cartas em uma linha em frente ao jogador
    private void AtualizarLayoutMao()
    {
        float totalWidth = (cartasNaMao.Count - 1) * cardSpacing;
        Vector3 startPosition = new Vector3(-totalWidth / 2f, 0, 0);

        for (int i = 0; i < cartasNaMao.Count; i++)
        {
            Vector3 cardPosition = startPosition + new Vector3(i * cardSpacing, 0, 0);
            // Anima a carta para a nova posição (opcional, mas fica bonito)
            cartasNaMao[i].transform.localPosition = cardPosition;
        }
    }

    // A lógica de remover a carta precisa ser adaptada para o clique 3D
    public void RemoverCartaDaMao(CardView cartaParaRemover)
    {
        if (cartasNaMao.Contains(cartaParaRemover))
        {
            CardManager.Instance.DescartarCarta(cartaParaRemover.cardData);
            cartasNaMao.Remove(cartaParaRemover);
            Destroy(cartaParaRemover.gameObject);

            // Reorganiza as cartas restantes na mão
            AtualizarLayoutMao();
        }
    }
}