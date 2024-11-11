using UnityEngine;
using TMPro;

public class ResourceVisual : MonoBehaviour
{
    public Resource resourceType;
    public TextMeshProUGUI text;
    [SerializeField] private ResourceBank resourceBank;

    private void Start()
    {
        if (resourceBank.GetResource(resourceType) != null)
        {
            resourceBank.GetResource(resourceType).OnValueChanged += UpdateDisplay;
            UpdateDisplay(resourceBank.GetResource(resourceType).Value);
        }
    }
    private void UpdateDisplay(int value)
    {
        text.text = value.ToString();
    }


}
