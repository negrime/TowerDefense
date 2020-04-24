using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public LayerMask Mask;
    private ShopController _shop;
    public event Action RightClickEvent;

    private void Awake()
    {
        _shop = FindObjectOfType<ShopController>();

        if (!_shop)
        {
            throw new Exception($"{gameObject.name} does not have component! - {_shop.GetType()}");
        }
    }


    private void Update()
    {
        InputUpdate();
    }


    private void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit, 1000, Mask)) return;
            Transform objectHit = hit.transform;
            
            if (objectHit.TryGetComponent(out Foundation foundation))
            {
                if (!foundation.IsFree)
                    return;
                _shop.SetFoundation( foundation, RectTransformUtility.WorldToScreenPoint(FindObjectOfType<Camera>(), objectHit.transform.position));
            }
        }
    }


    public void RightMouseUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit, 1000, Mask)) return;
            Transform objectHit = hit.transform;
            
            if (objectHit.TryGetComponent(out Cell cell))
            {
                if (!cell.IsFree)
                    return;
                RightClickEvent?.Invoke();

                cell.SpawnFoundation();
            }
        }
    }
    
}
