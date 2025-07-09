using UnityEngine;
using System.Collections.Generic;

public enum TurnState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleScript : MonoBehaviour
{
    public TurnState state;

    public List<string> enemyNames = new List<string> { "Inimigo 1", "Inimigo 2" };

    public GameObject jogarButton;
    public GameObject mensagemUI;
    public GameObject dinheiroUI;
    public GameObject passarButton;

    private GameObject playerSelectedBoat;
    private Dictionary<string, GameObject> enemySelectedBoats = new Dictionary<string, GameObject>();

    private bool gameStarted = false;

    public void StartGame()
    {
        gameStarted = true;
        state = TurnState.PLAYERTURN;

        // Esconde o botão Jogar e mostra Mensagem e Dinheiro
        jogarButton.SetActive(false);
        mensagemUI.SetActive(true);
        dinheiroUI.SetActive(true);

        Debug.Log("Jogo iniciado! Agora você pode escolher um barco.");
    }
    
    public void OnPassarButton()
    {
        SwitchTurn();
        passarButton.SetActive(false); // Esconde botão ao trocar turno
    }


    void Start()
    {
        // No início, deixa Mensagem e Dinheiro ocultos
        mensagemUI.SetActive(false);
        dinheiroUI.SetActive(false);
        passarButton.SetActive(false);
    }

    void Update()
    {
        if (!gameStarted) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchTurn();
        }

        if (state == TurnState.PLAYERTURN)
        {
            HandlePlayerInput();
        }
    }

    void SwitchTurn()
    {
        if (state == TurnState.PLAYERTURN)
        {
            if (playerSelectedBoat == null)
            {
                Debug.Log("Você precisa escolher um barco antes de passar o turno!");
                return;
            }

            state = TurnState.ENEMYTURN;
            Debug.Log("Turno dos Inimigos.");
            EnemySelectBoats();
        }
        else if (state == TurnState.ENEMYTURN)
        {
            state = TurnState.PLAYERTURN;
            playerSelectedBoat = null;
            enemySelectedBoats.Clear();
            Debug.Log("Novo turno do Jogador.");
        }
    }

    void HandlePlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Boat"))
            {
                if (playerSelectedBoat == null)
                {
                    playerSelectedBoat = hit.collider.gameObject;
                    Debug.Log($"Jogador selecionou o barco: {playerSelectedBoat.name}");

                    mensagemUI.SetActive(false);
                    passarButton.SetActive(true); // Ativa botão Passar
                }
                else
                {
                    Debug.Log("Você já escolheu um barco neste turno.");
                }
            }
        }
    }

   

    void EnemySelectBoats()
    {
        GameObject[] allBoats = GameObject.FindGameObjectsWithTag("Boat");

        List<GameObject> availableBoats = new List<GameObject>(allBoats);
        availableBoats.Remove(playerSelectedBoat);

        foreach (string enemyName in enemyNames)
        {
            if (availableBoats.Count == 0)
            {
                Debug.Log("Não há barcos suficientes para os inimigos.");
                break;
            }

            int randomIndex = Random.Range(0, availableBoats.Count);
            GameObject chosenBoat = availableBoats[randomIndex];
            enemySelectedBoats.Add(enemyName, chosenBoat);
            Debug.Log($"{enemyName} escolheu o barco: {chosenBoat.name}");

            availableBoats.RemoveAt(randomIndex);
        }

        Debug.Log("Inimigos terminaram.");
    }
}
