using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IDamage
{

    private MainAI _mainAi;
    
    private NavMeshAgent _agent;

    [SerializeField]
    private EnemyStats _stats;

    public EnemyStats Stats => _stats;

    [SerializeField]
    private float _currentHp;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentHp = _stats.Hp;
        _mainAi = FindObjectOfType<MainAI>();
        _agent.speed = _stats.Speed;
        
        if (!_mainAi)
        {
            throw new Exception($"{gameObject.name} does not have component! - {_mainAi.GetType()}");
        }
    }


    private void Update()
    {
        if (_mainAi.TryToBuildPath())
        {
            BuildPathToTarget();
        }
        else
        {
            _agent.ResetPath();
        }
    }


    private void BuildPathToTarget()
    {
        _agent.SetDestination(_mainAi.Target.position);
    }


    public void ApplyDamage(int value)
    {
        _currentHp -= value;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_currentHp <= 0)
        {
            FindObjectOfType<WaveManager>().DeleteEnemyFromMap(gameObject);
            FindObjectOfType<MoneyController>().UpdateMoney(_stats.Award);
            Destroy(gameObject);
        }
    }
}
