using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _destroyTime;

    public int Damage { private get; set; }

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }



    private void OnCollisionEnter(Collision other)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamage enemy))
        {
            enemy.ApplyDamage(Damage);
            Destroy(gameObject);
        }    
    }
}
