using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader = default;
    [SerializeField] private MoneySO _moneySO = default;

    // Fruit Per Hour
    private float _currentTime = 0.0f;

    private void OnEnable()
    {
        _inputReader.TapEvent += TapGain;

        _moneySO.GetTimeMoney();
    }

    private void OnDisable()
    {
        _inputReader.TapEvent -= TapGain;
    }

    private void TapGain()
    {
        _moneySO.GainFruit();
        _moneySO.ShowMoney();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= 1.0f)
        {
            _moneySO.GainFruitAutomatically();
            _currentTime = 0;
        }
    }

    
}
