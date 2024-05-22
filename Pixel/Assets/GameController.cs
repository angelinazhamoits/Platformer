using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int _points;
    [SerializeField] private int _kiwiPrice;
    [SerializeField] private int _applePrice;
    [SerializeField] private TextMeshProUGUI _summ;

    public void PointCounter(FruitType fruitType)
    {
        switch (fruitType)
        {
            case FruitType.Kiwi:
                _points += _kiwiPrice;
                break;
            case FruitType.Apple:
                _points += _applePrice;
                break;
        }
        Summ();
    }
    

    private void Summ()
    {
        _summ.text = $"Points: {_points}";
    }
}
