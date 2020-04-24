using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MainAI : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    private NavMeshAgent _agent;

    public Transform Target => _target;
    public GameObject PreviousFoundation;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (!_target)
        {
            throw new Exception($"{gameObject.name} does not have component! - {_target.GetType()}");
        }
        
    }


    private void Update()
    {
        if (!TryToBuildPath())
        {
            Destroy(PreviousFoundation);
        }
    }

    public bool TryToBuildPath()
    {
        NavMeshPath path = new NavMeshPath();

        return ((_agent.CalculatePath(_target.position, path) && path.status != NavMeshPathStatus.PathPartial && path.status == NavMeshPathStatus.PathComplete));
    }
}
