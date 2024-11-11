using System;
using UnityEngine;

public class ObservableInt
{
    private int value;
    public event Action<int> OnValueChanged;

    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}
