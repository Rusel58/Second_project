using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProductionBuilding : MonoBehaviour
{
    public ResourceBank resourceBank;
    public float ProductionTime = 0.2f;

    // Публичные массивы для установки ссылок через инспектор
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

        // Находим нужные кнопку и слайдер по имени родительского объекта
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

        // Деактивируем кнопку
        if (targetButton != null)
        {
            targetButton.interactable = false;
        }

        float elapsedTime = 0f;

        while (elapsedTime < ProductionTime)
        {
            elapsedTime += Time.deltaTime;

            // Обновляем прогресс
            if (targetSlider != null)
            {
                targetSlider.value = elapsedTime / ProductionTime;
            }

            yield return null;
        }

        // Добавляем ресурс
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

        // Сбрасываем прогресс
        if (targetSlider != null)
        {
            targetSlider.value = 0f;
        }

        // Активируем кнопку
        if (targetButton != null)
        {
            targetButton.interactable = true;
        }

        isProducing = false;
    }
}