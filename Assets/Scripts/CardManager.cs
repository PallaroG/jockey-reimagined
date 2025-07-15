using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private static CardManager _instance;

    public static CardManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<CardManager>();
                if (_instance == null)
                {
                    Debug.LogError("ERRO: Um CardManager é necessário na cena, mas não foi encontrado.");
                }
            }
            return _instance;
        }
    }

    [Header("Configuração do Deck")]
    [Tooltip("Arraste TODOS os seus assets de CardData para esta lista.")]
    public List<CardData> deckCompleto;

    private List<CardData> baralhoAtual = new List<CardData>();
    private List<CardData> descarte = new List<CardData>();

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        ReiniciarBaralho();
    }

    public void ReiniciarBaralho()
    {
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
        if (baralhoAtual.Count == 0 && descarte.Count > 0)
        {
            baralhoAtual.AddRange(descarte);
            descarte.Clear();
            Embaralhar();
        }
        
        if (baralhoAtual.Count == 0)
        {
            Debug.LogWarning("Não há mais cartas para comprar!");
            return null;
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