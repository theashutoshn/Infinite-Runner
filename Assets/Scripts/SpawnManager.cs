using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] _enemyPrefab;
    private bool _stopSpawning;
    
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawner()
    {
        while (_stopSpawning == false)
        {
            Vector3 enemySpawnPos = new Vector3(Random.Range(-1.66f, 1.66f), 0.514f, 8f);
            Instantiate(_enemyPrefab[Random.Range(0,5)], enemySpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
