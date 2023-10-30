using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _coinSpeed = 4f;
    void Start()
    {
        
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
}
