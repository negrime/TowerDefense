using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] private int _lives;

    [SerializeField] private Text _livesTxt;

    private void Start()
    {
        UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Destroy(other.gameObject);
            _lives -= enemy.Stats.Damage;
            UpdateText();
            if (_lives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


    private void UpdateText()
    {
        _livesTxt.text = $"Base health: {_lives}";
    }
}
