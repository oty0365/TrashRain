using System;
using UnityEngine;

public class Stat
{
    public Stat(float initialValue)
    {
        _value = initialValue;
        _hasLimit = false;
    }

    public Stat(float initialValue, float maxValue)
    {
        _maxValue = maxValue;
        _value = Mathf.Clamp(initialValue, 0f, _maxValue);
        _hasLimit = true;
    }

    private float _value;
    private float _maxValue;
    private bool _hasLimit;

    public event Action<float> OnValueChanged;
    public event Action<float, float> OnValueChangedWithMax;


    public float Value
    {
        get => _value;
        set
        {
            float clamped = _hasLimit ? Mathf.Clamp(value, 0f, _maxValue) : value;
            if (Mathf.Approximately(_value, clamped)) return;
            _value = clamped;
            OnValueChanged?.Invoke(_value);
            OnValueChangedWithMax?.Invoke(_value, _maxValue);
        }
    }

    public float MaxValue
    {
        get => _maxValue;
        set
        {
            if (!_hasLimit) return;
            _maxValue = Mathf.Max(0f, value);
            _value = Mathf.Clamp(_value, 0f, _maxValue);
            OnValueChanged?.Invoke(_value);
            OnValueChangedWithMax?.Invoke(_value, _maxValue);
        }
    }

    public bool HasLimit => _hasLimit;
    public float Ratio => _hasLimit && _maxValue > 0f ? _value / _maxValue : 0f;

    public void Add(float amount) => Value += amount;
    public void Subtract(float amount) => Value -= amount;
    public void Reset() => Value = _hasLimit ? _maxValue : 0f;
    public void ForceNotify()
    {
        OnValueChanged?.Invoke(_value);
        OnValueChangedWithMax?.Invoke(_value, _maxValue);
    }
}