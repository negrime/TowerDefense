using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private int _waveIndex;
    
    [SerializeField]
    private List<GameObject> _enemiesPrefabs;
    
    [SerializeField]
    private GameObject _Boss;

    [SerializeField]
    private int _enemyCount;
    

    [SerializeField]
    private Transform _spawnPlace;

    public event Action WaveEndEvent;

    private List<GameObject> _enemiesOnMap = new List<GameObject>();

    public List<GameObject> EnemiesOnMap => _enemiesOnMap;


    public void DeleteEnemyFromMap(GameObject gameObject)
    {
        if (_enemiesOnMap.Contains(gameObject))
        {
            _enemiesOnMap.Remove(gameObject);
            EndWaveCheck();
        }
    }

    public void StartNewWave()
    {
        _waveIndex++;
        StartCoroutine(SpawnWave());
    }



    private void EndWaveCheck()
    {
        if (_enemiesOnMap.Count == 0)
        {
            _enemyCount += _enemyCount / 2;
            WaveEndEvent?.Invoke();
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < 2 ; i++)
        {
            StartCoroutine(SpawnBurst(_enemyCount / 2));
            yield return new WaitForSeconds(_enemyCount / 2);
        }
        yield return new WaitForSeconds(2);
        GameObject go = Instantiate(_Boss, _spawnPlace.position, Quaternion.identity);
        _enemiesOnMap.Add(go);
    }

    private IEnumerator SpawnBurst(int count)
    {
        for (int i = 0; i < count ; i++)
        {
            GameObject go = Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Count)], _spawnPlace.position, Quaternion.identity);
            _enemiesOnMap.Add(go);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
}
