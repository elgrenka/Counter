using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        if (_text == null || _counter == null)
        {
            Debug.LogError("Text или Counter не назначены в инспекторе.");
        }

        _counter.ValueChanged += UpdateText;
        UpdateText(0);
    }

    private void OnDestroy()
    {
        if (_counter != null)
        {
            _counter.ValueChanged -= UpdateText;
        }
    }

    private void UpdateText(int value)
    {
        _text.text = $"{value}";
    }
}