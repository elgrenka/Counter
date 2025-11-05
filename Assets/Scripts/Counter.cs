using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private Coroutine _countCoroutine;
    private bool _isCounting;
    private int _currentCount;

    private void Start()
    {
        _text.text = "0";
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ToggleCount();
    }
    
    private void ToggleCount()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            _countCoroutine = StartCoroutine(Countdown(0.5f));
        }
        else
        {
            if (_countCoroutine != null)
            {
                StopCoroutine(_countCoroutine);
            
                _countCoroutine = null;
            }
        }
    }
    
    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isCounting)
        {
            DisplayCountdown(_currentCount);
            
            yield return wait;
            
            _currentCount++;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }
}
