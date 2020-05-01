using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{

    [SerializeField]
    private Text _moneyText;
    [SerializeField]
    private int _money;

    private void Start()
    {
        UpdateText();
    }

    public bool TryToBuyItem(int price)
    {
        return _money >= price;
    }

    public void UpdateMoney(int value)
    {
        _money += value;
        UpdateText();
    }


    private void UpdateText()
    {
        _moneyText.text = $"${_money}";
    }
}
