using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopStats : MonoBehaviour
{
    [SerializeField]
    private int _price;

    [SerializeField]
    private Vector3 _spawnOffset;

    public int Price => _price;

    public Vector3 SpawnOffset => _spawnOffset;
}
