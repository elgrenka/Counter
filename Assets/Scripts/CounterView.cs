using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private Counter _counter;

    private void Start()
    {
        _counter = FindAnyObjectByType<Counter>();
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
        if (_text != null)
        {
            _text.text = $"{value}";
        }
        else
        {
            Debug.Log($"{value}");
        }
    }
}