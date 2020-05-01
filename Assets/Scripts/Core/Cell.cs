using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    
    private Color _startMaterialColor;
    private Material _currentMaterialColor;

    [SerializeField]
    private GameObject _foundation;

    private bool _isFree;

    public bool IsFree => _isFree;

    void Start()
    {
        _isFree = true;
        _currentMaterialColor = GetComponent<MeshRenderer>().materials[0];
        _startMaterialColor = _currentMaterialColor.color;
    }
    
    public void SpawnFoundation()
    {
        _isFree = false;

       FindObjectOfType<MainAI>().PreviousFoundation =  Instantiate(_foundation, transform.position, Quaternion.identity);
    }
    }
