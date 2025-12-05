using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    public event Action<int> ValueChanged;

    private int _currentValue;
    private bool _isCounting;
    private Coroutine _countingCoroutine;

    private InputReader _inputReader;

    private void Start()
    {
        _inputReader = FindAnyObjectByType<InputReader>();

        if (_inputReader != null)
        {
            _inputReader.MouseButtonPressed += OnMouseButtonPressed;
        }
        else
        {
            Debug.LogError("InputReader не найден.");
        }
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
        {
            _inputReader.MouseButtonPressed -= OnMouseButtonPressed;
        }
    }

    private void OnMouseButtonPressed()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            _countingCoroutine = StartCoroutine(Count());
        }
        else
        {
            if (_countingCoroutine != null)
            {
                StopCoroutine(_countingCoroutine);
            }
        }
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(0.5f);
        while (enabled)
        {
            _currentValue++;
            ValueChanged?.Invoke(_currentValue);
            yield return wait;
        }
    }
}