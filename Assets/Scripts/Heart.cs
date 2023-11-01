using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private float _heartSpeed = 3f;
    private bool _stopHeartSpawning = false;
    private Player _player;
    void Start()
    {
        _player = GetComponent<Player>();
        float playerLives = _player.playerLives;
        if (playerLives < 2)
        {
            Debug.Log("Heart Is comming");
            StartCoroutine(HeartSpawner());
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * _heartSpeed * Time.deltaTime);
    }

    IEnumerator HeartSpawner()
    {
        while (_stopHeartSpawning == false)
        {
            Vector3 heartSpawnPos = new Vector3(Random.Range(-1.66f, 1.66f), 0.207f, 8f);
            Instantiate(this, heartSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
