using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    public event Action MouseButtonPressed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonPressed?.Invoke();
        }
    }
}