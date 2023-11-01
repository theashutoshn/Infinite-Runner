using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _coinSpeed = 4f;

    private Player _player;
    void Start()
    {
        _player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * _coinSpeed * Time.deltaTime);
        if (transform.position.z < -8.85f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Coin Collected");
            _player.Score();
            Destroy(this.gameObject);
        }
    }
}
