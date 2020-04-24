using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStats
{
    [SerializeField]
    private int _damage;
    
    [SerializeField]
    private float _speed;
    
    [SerializeField]
    private int _hp;

    [SerializeField]
    private int _award;
    
    public int Hp => _hp;

    public int Damage => _damage;
    public float Speed => _speed;

    public int Award => _award;
}
