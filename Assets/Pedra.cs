using UnityEngine;

public class Stone : MonoBehaviour
{
    
    public int stoneWeight = 40;

    
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

