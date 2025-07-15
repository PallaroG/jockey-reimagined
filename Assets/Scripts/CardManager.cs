using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("Configuração do Deck")]
    [Tooltip("Arraste TODOS os seus assets de CardData para esta lista.")]
    public List<CardData> deckCompleto;

    private List<CardData> baralhoAtual = new List<CardData>();
    private List<CardData> descarte = new List<CardData>();

    // Singleton para fácil acesso de outros scripts
    public static CardManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        // Inicia o jogo com o baralho pronto
        ReiniciarBaralho();
    }

    public void ReiniciarBaralho()
    {
        // Copia todos os CardData do deck configurado para o baralho que será usado no jogo.
        baralhoAtual.Clear();
        baralhoAtual.AddRange(deckCompleto);
        Embaralhar();
    }

    public void Embaralhar()
    {
        for (int i = 0; i < baralhoAtual.Count; i++)
        {
            CardData temp = baralhoAtual[i];
            int randomIndex = Random.Range(i, baralhoAtual.Count);
            baralhoAtual[i] = baralhoAtual[randomIndex];
            baralhoAtual[randomIndex] = temp;
        }
        Debug.Log("Baralho embaralhado!");
    }

    public CardData ComprarCarta()
    {
        if (baralhoAtual.Count == 0)
        {
            // Se o baralho acabar, reembaralha o descarte (se houver cartas lá)
            if (descarte.Count > 0)
            {
                Debug.Log("Baralho acabou! Reembaralhando o descarte...");
                baralhoAtual.AddRange(descarte);
                descarte.Clear();
                Embaralhar();
            }
            else
            {
                Debug.LogWarning("Não há mais cartas para comprar no baralho ou no descarte!");
                return null;
            }
        }

        CardData cartaComprada = baralhoAtual[0];
        baralhoAtual.RemoveAt(0);
        return cartaComprada;
    }
    
    public void DescartarCarta(CardData carta)
    {
        descarte.Add(carta);
    }
}