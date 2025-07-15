using UnityEngine;

// A linha abaixo permite que você crie assets de carta no menu da Unity.
[CreateAssetMenu(fileName = "NovaCarta", menuName = "Jockey/Carta")]
public class CardData : ScriptableObject
{
    [Header("Informações Visuais")]
    public string nomeDaCarta;
    public Sprite arteDaCarta;

    [Header("Valores Funcionais da Carta")]
    [Tooltip("O número de casas que esta carta move um barco.")]
    public int valorMovimento;

    [Tooltip("O ID do barco que esta carta representa. Ex: 0=Azul, 1=Vermelho...")]
    public int idDoBarco; 
}