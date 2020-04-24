using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PrepareStageView))]
public class PrepareStage : MonoBehaviour
{
    [SerializeField]
    private int _startFoundationCount;
    
    private int _foundationCount;

    [SerializeField]
    private bool _isPrepareStage;

        //  public bool IsPrepareStage => _isPrepareStage;
    
    public event Action StartWaveEvent;
  
    private InputManager _input;

    private PrepareStageView _view;
    

    private void Start()
    {
        _view = GetComponent<PrepareStageView>();
        _input = FindObjectOfType<InputManager>();
        _input.RightClickEvent += InputOnRightClickEvent;
        if (!_input)
        {
            throw new Exception($"{gameObject.name} does not have component! - {_input.GetType()}");
        }
        
        _foundationCount = _startFoundationCount;
        _view.UpdateFoundationCountText(_foundationCount);
    }

    private void InputOnRightClickEvent()
    {
        _foundationCount--;
        _view.UpdateFoundationCountText(_foundationCount);
    }

    private void Update()
    {
        if (_isPrepareStage && _foundationCount > 0)
        {
            _input.RightMouseUpdate();
        }
    }

    public void OnStartWaveClick()
    {
        _isPrepareStage = false;
        _view.SetActivePanel(false);
        StartWaveEvent?.Invoke();
    }

    public void StartStage()
    {
        _view.SetActivePanel(true);
        _foundationCount = _startFoundationCount / 2;
        _view.UpdateFoundationCountText(_foundationCount);
        _isPrepareStage = true;
    }
}
