using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public int weight = 80;
    private bool hasStone = false;
    private GameObject stone;
    private List<IObserver> observers = new List<IObserver>();

    private void Start()
    {
        AddObserver(FindObjectOfType<PlayerWeightTextObserver>());
        NotifyObservers();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && hasStone)
        {
            DropStone();
        }
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.UpdateWeight(weight);
        }
    }

    public void PickStone(GameObject stoneObject, int stoneWeight)
    {
        if (!hasStone)
        {
            weight += stoneWeight;
            hasStone = true;
            stone = stoneObject;
            stone.SetActive(false);
            NotifyObservers();
        }
    }

    private void DropStone()
    {
        if (hasStone)
        {
            weight -= 40;
            hasStone = false;
            stone.SetActive(true);
            stone.transform.position = new Vector3(0, 0.5f, 0);
            NotifyObservers();
        }
    }
}
