using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private int waveIndex;
    
    [SerializeField]
    private List<GameObject> _enemiesPrefabs;

    [SerializeField]
    private int _enemyCount;
    

    [SerializeField]
    private Transform spawnPlace;

    public event Action WaveEndEvent;

    private List<GameObject> enemiesOnMap = new List<GameObject>();

    public List<GameObject> EnemiesOnMap => enemiesOnMap;


    public void DeleteEnemyFromMap(GameObject gameObject)
    {
        if (enemiesOnMap.Contains(gameObject))
        {
            enemiesOnMap.Remove(gameObject);
            EndWaveCheck();
        }
    }

    public void StartNewWave()
    {
        waveIndex++;
        StartCoroutine(SpawnWave());
    }



    private void EndWaveCheck()
    {
        if (enemiesOnMap.Count == 0)
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
   
    }

    private IEnumerator SpawnBurst(int count)
    {
        for (int i = 0; i < count ; i++)
        {
            GameObject go = Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Count)], spawnPlace.position, Quaternion.identity);
            enemiesOnMap.Add(go);
            yield return new WaitForSeconds(Random.Range(0.6f, 1));
        }
    }
}
