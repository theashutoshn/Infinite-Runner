using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private float _enemySpeed = 5f;

    private Player _player;
    private float _damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * _enemySpeed * Time.deltaTime);
        if (transform.position.z < -8.85f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            _player.TakeDamage(30);
            
        }
    }
}
