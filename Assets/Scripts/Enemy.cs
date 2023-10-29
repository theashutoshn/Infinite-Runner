using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private float _enemySpeed = 5f;
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
}
