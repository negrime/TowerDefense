using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaveManager))]
public class GameManager : MonoBehaviour
{
    private PrepareStage _prepareStage;

    private WaveManager _wave;
    private void Start()
    {
        _wave = GetComponent<WaveManager>();
        _prepareStage = FindObjectOfType<PrepareStage>();
        
        _prepareStage.StartWaveEvent += OnStartWaveEvent;
        _wave.WaveEndEvent += WaveOnWaveEndEvent;

    }

    private void WaveOnWaveEndEvent()
    {
        _prepareStage.StartStage();
    }

    private void OnStartWaveEvent()
    {
        _wave.StartNewWave();
    }


}
