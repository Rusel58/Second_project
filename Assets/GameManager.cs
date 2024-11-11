using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ResourceBank resourceBank;
    public ResourceVisual resourseVisual;

    private void Awake()
    {
        resourceBank = FindObjectOfType<ResourceBank>();
        InitializeResources();
    }

    private void InitializeResources()
    {
        resourceBank.GetResource(Resource.Humans).Value = 10;
        resourceBank.GetResource(Resource.Food).Value = 5;
        resourceBank.GetResource(Resource.Wood).Value = 5;
    }
}
