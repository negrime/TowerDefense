using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPanel;
    public void SetActive(bool isActive = true)
    {
        _shopPanel.SetActive(isActive);
    }
}
