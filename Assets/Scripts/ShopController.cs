using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurretType
{
    Simple = 0,
    Faster = 1
}

public class ShopController : MonoBehaviour
{
    private Foundation _currentFoundation;

    private ShopView _view;

    private MoneyController _moneyController;

    [SerializeField] 
    private List<GameObject> turrets;
    
    private void Awake()
    {
        _view = GetComponent<ShopView>();
        _moneyController = FindObjectOfType<MoneyController>();

        if (!_view)
        {
            throw new Exception($"{gameObject.name} does not have component! - {_view.GetType()}");
        }
        
        if (!_moneyController)
        {
            throw new Exception($"{gameObject.name} does not have component! - {_moneyController.GetType()}");
        }
    }


    public void SpawnTurret(int turretIndex)
    {
        if (!Enum.IsDefined(typeof(TurretType), turretIndex))
        {
            return;
        }

        var turret = turrets[turretIndex];
        var turretPrice = turret.GetComponent<ShopStats>().Price;
        if (_moneyController.TryToBuyItem(turretPrice))
        {
            _moneyController.UpdateMoney(-turretPrice);
            _currentFoundation.ReservePlace();
            var go = Instantiate(turrets[turretIndex], _currentFoundation.transform.position , Quaternion.identity);
            go.transform.position += go.GetComponent<ShopStats>().SpawnOffset;
            _view.SetActive(false);
        }
    }


    public void OnExitClick()
    {
        _view.SetActive(false);
    }
    

    public void SetFoundation(Foundation foundation, Vector3 position)
    {
        _currentFoundation = foundation;
        transform.position = position;
        _view.SetActive(true);
    }
}
