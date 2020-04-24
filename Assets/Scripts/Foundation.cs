using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foundation : MonoBehaviour
{
    private bool isFree;

    public bool IsFree => isFree;

    private GameObject _canvas;

    void Start()
    {
        _canvas = GameObject.FindWithTag("GameController");
        isFree = true;
    }
    

    public void ReservePlace()
    {
        isFree = false;
    }
}
