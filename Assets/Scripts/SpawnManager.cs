using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] _enemyPrefab;
    private bool _stopSpawning;
    public GameObject _coinPrefab;

    public GameObject heartPrefab;
    private bool _stopHeartSpawning;

    
    void Start()
    {
        
        StartCoroutine(EnemySpawner());
        StartCoroutine(CoinSpawner());
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHeartSpawning()
    {
        if (!_stopHeartSpawning)
        {
            _stopHeartSpawning = false;
            StartCoroutine(HeartSpawner());
        }
    }
    public void StopHeartSpawning()
    {
         _stopHeartSpawning = true;
    }

    IEnumerator EnemySpawner()
    {
        while (_stopSpawning == false)
        {
            Vector3 enemySpawnPos = new Vector3(Random.Range(-1.66f, 1.66f), 0.3f, 8f);
            Instantiate(_enemyPrefab[Random.Range(0,5)], enemySpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator CoinSpawner()
    {
        while (_stopSpawning == false)
        {
            Vector3 coinSpawnPos = new Vector3(Random.Range(-1.66f, 1.66f), 0.207f, 8f);
            Instantiate(_coinPrefab, coinSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
            
    }

    IEnumerator HeartSpawner()
    {
        while (_stopHeartSpawning == false)
        {
            Vector3 heartSpawnPos = new Vector3(Random.Range(-1.66f, 1.66f), 0.207f, 8f);
            Instantiate(heartPrefab, heartSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

}
