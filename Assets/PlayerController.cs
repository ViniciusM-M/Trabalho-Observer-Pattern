using UnityEngine;
using TMPro; // Adiciona o namespace para usar TextMeshPro

public class PlayerController : MonoBehaviour
{
    // Referência para o componente de texto da UI usando TextMeshProUGUI
    public TextMeshProUGUI playerWeightText;

    // Peso inicial do jogador, definido como 80kg
    public int weight = 80;

    // Variável que indica se o jogador já possui uma pedra no inventário
    private bool hasStone = false;

    // Referência ao objeto da pedra que o jogador pegou
    private GameObject stone;

    private void Start()
    {
        // Atualiza o texto de peso na interface no início do jogo
        UpdateWeightText();
    }

    private void Update()
    {
        // Verifica se a tecla "Q" foi pressionada e o jogador tem uma pedra
        if (Input.GetKeyDown(KeyCode.Q) && hasStone)
        {
            // Se sim, chama o método para largar a pedra
            DropStone();
        }
    }

    // Método chamado para adicionar a pedra ao inventário
    public void PickStone(GameObject stoneObject, int stoneWeight)
    {
        // Verifica se o jogador ainda não possui uma pedra
        if (!hasStone)
        {
            // Aumenta o peso do jogador pelo peso da pedra
            weight += stoneWeight;

            // Marca que o jogador agora possui uma pedra
            hasStone = true;

            // Guarda uma referência para o objeto da pedra
            stone = stoneObject;

            // Esconde o objeto pedra da cena
            stone.SetActive(false);

            // Atualiza o texto de peso na interface
            UpdateWeightText();
        }
    }

    // Método chamado para largar a pedra e reduzir o peso do jogador
    private void DropStone()
    {
        // Verifica se o jogador tem uma pedra
        if (hasStone)
        {
            // Reduz o peso do jogador pelo peso da pedra (40 kg)
            weight -= 40;

            // Marca que o jogador não possui mais a pedra
            hasStone = false;

            // Mostra a pedra novamente na cena
            stone.SetActive(true);

            // Reposiciona a pedra para a posição inicial (ajuste opcional)
            stone.transform.position = new Vector3(0, 0.5f, 0);

            // Atualiza o texto de peso na interface
            UpdateWeightText();
        }
    }

    // Atualiza o texto de peso na interface com o peso atual do jogador
    private void UpdateWeightText()
    {
        playerWeightText.text = $"Peso do Jogador: {weight} kg";
    }
}
