using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // A lista agora vai guardar apenas os DADOS, não os objetos visuais.
    public List<CardData> cartasNaMao_Data = new List<CardData>();

    public void ComprarCartasIniciais(int quantidade)
    {
        Debug.Log("--- Iniciando compra de cartas iniciais (teste de console) ---");
        for (int i = 0; i < quantidade; i++)
        {
            ComprarUmaCarta();
        }
    }

    public void ComprarUmaCarta()
    {
        // 1. Tenta pegar a "lógica" da carta do CardManager
        CardData novaCartaData = CardManager.Instance.ComprarCarta();

        // 2. Verifica se a carta foi recebida com sucesso
        if (novaCartaData != null)
        {
            // 3. AVISA no console qual carta foi comprada.
            Debug.Log($"<color=lime>CONSOLE: Carta Comprada:</color> {novaCartaData.nomeDaCarta} (Barco ID: {novaCartaData.idDoBarco}, Mov: {novaCartaData.valorMovimento})");

            // 4. Adiciona os dados da carta à nossa lista de controle.
            cartasNaMao_Data.Add(novaCartaData);
        }
        else
        {
            // Se CardManager.Instance.ComprarCarta() retornar null, o erro está nele.
             Debug.LogError("Falha ao comprar carta. O CardManager não retornou dados. Verifique o CardManager e seu deck.");
        }
    }
}