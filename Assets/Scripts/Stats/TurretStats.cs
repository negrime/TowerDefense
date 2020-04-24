using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TurretStats
{
    [SerializeField]
    private int _damage;
    
    [SerializeField]
    private float _range;

    [SerializeField]
    private float _timeToShoot;

    [SerializeField] 
    private float _rotateSpeed;
   
    public int Damage => _damage;
    public float Range => _range;

    public float TimeToShoot => _timeToShoot;
    
    public float RotateSpeed => _rotateSpeed;
}
