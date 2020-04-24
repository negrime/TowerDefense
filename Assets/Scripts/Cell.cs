using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    
    private Color _startMaterialColor;
    private Material _currentMaterialColor;

    public GameObject Foundation;

    private bool isFree;

    public bool IsFree => isFree;


    void Start()
    {
        isFree = true;
        _currentMaterialColor = GetComponent<MeshRenderer>().materials[0];
        _startMaterialColor = _currentMaterialColor.color;
    }
    

    

    public void SpawnFoundation()
    {
        isFree = false;

       FindObjectOfType<MainAI>().PreviousFoundation =  Instantiate(Foundation, transform.position, Quaternion.identity);
    }
    
}
