using UnityEngine;

public class Stone : MonoBehaviour
{
    // Peso da pedra (40kg)
    public int stoneWeight = 40;

    // Método chamado quando o jogador clica na pedra com o mouse
    private void OnMouseDown()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.PickStone(gameObject, stoneWeight);
        }
    }
}

