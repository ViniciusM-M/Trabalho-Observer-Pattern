using UnityEngine;
using TMPro;

public class PlayerWeightTextObserver : MonoBehaviour, IObserver
{
    public TextMeshProUGUI weightText;

    public void UpdateWeight(int newWeight)
    {
        weightText.text = $"Peso do Jogador: {newWeight} kg";
    }
}
