using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProductionBuilding : MonoBehaviour
{
    public ResourceBank resourceBank;
    public float ProductionTime = 0.2f;

    // ��������� ������� ��� ��������� ������ ����� ���������
    public Button[] productionButtons;
    public Slider[] progressSliders;
    private bool isProducing = false;

    
    public void Plus(string resourceType)
    {
        if (!isProducing)
        {
            StartCoroutine(ProduceResource(resourceType));
        }
    }

    private IEnumerator ProduceResource(string resourceType)
    {
        isProducing = true;

        // ������� ������ ������ � ������� �� ����� ������������� �������
        Button targetButton = null;
        Slider targetSlider = null;

        foreach (Button button in productionButtons)
        {
            if (button.transform.parent.name == resourceType)
            {
                targetButton = button;
                break;
            }
        }

        foreach (Slider slider in progressSliders)
        {
            if (slider.transform.parent.name == resourceType)
            {
                targetSlider = slider;
                break;
            }
        }

        // ������������ ������
        if (targetButton != null)
        {
            targetButton.interactable = false;
        }

        float elapsedTime = 0f;

        while (elapsedTime < ProductionTime)
        {
            elapsedTime += Time.deltaTime;

            // ��������� ��������
            if (targetSlider != null)
            {
                targetSlider.value = elapsedTime / ProductionTime;
            }

            yield return null;
        }

        // ��������� ������
        switch (resourceType)
        {
            case "Humans":
                resourceBank.ResourcePlus(Resource.Humans);
                break;
            case "Food":
                resourceBank.ResourcePlus(Resource.Food);
                break;
            case "Wood":
                resourceBank.ResourcePlus(Resource.Wood);
                break;
            case "Stone":
                resourceBank.ResourcePlus(Resource.Stone);
                break;
            case "Gold":
                resourceBank.ResourcePlus(Resource.Gold);
                break;
        }

        // ���������� ��������
        if (targetSlider != null)
        {
            targetSlider.value = 0f;
        }

        // ���������� ������
        if (targetButton != null)
        {
            targetButton.interactable = true;
        }

        isProducing = false;
    }
}