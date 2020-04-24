using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

[RequireComponent(typeof(SphereCollider))]
public class Turret : MonoBehaviour, IAttack
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private TurretStats _stats;
    [SerializeField]
    private GameObject _shootPos;

    private WaveManager _waveManager;
    
    
    private GameObject _currentTarget;


    private float currentTime;
    
    


    
    private void Start()
    {
        currentTime = 0;
        GetComponent<SphereCollider>().radius = _stats.Range;
        _waveManager = FindObjectOfType<WaveManager>();
    }
    
    private void Update()
    {
        UpdateTarget();
        UpdateShootCoolDown();
    }

    private void UpdateTarget()
    {
        if (!(_waveManager.EnemiesOnMap.Count > 0))
        {
            return;
        }


        if (!_currentTarget)
        {
            _currentTarget =  GetNearestTarget(_waveManager.EnemiesOnMap);
            return;
        }

        if (Vector3.Distance(_currentTarget.transform.position, transform.position) > _stats.Range)
        {
            _currentTarget = null;
            return;
        }
        
        

        var direction = _currentTarget.transform.position - transform.position;
        Vector3 rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction),
            Time.deltaTime * _stats.RotateSpeed).eulerAngles;
        transform.eulerAngles = new Vector3(0, rotation.y, 0);
        
        Attack();
     }
    

    private GameObject GetNearestTarget(IEnumerable<GameObject> collection)
    {
        var min = _stats.Range;
        GameObject result = null;

    
        foreach (var item in collection)
        {
            var distance = Vector3.Distance(item.transform.position, transform.position);
            if (distance < min)
            {
                min = distance;
                result = item;
            }
        }
        return result;
    }

    public void Attack()
    {
        if (currentTime <= 0)
        {
            GameObject bullet = Instantiate(_bullet, _shootPos.transform.position, _shootPos.transform.rotation);
            bullet.GetComponent<Bullet>().Damage = _stats.Damage;
            currentTime = _stats.TimeToShoot;
        }
    }

    private void UpdateShootCoolDown()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _stats.Range);
    }
}
