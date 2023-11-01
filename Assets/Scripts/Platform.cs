using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private float _platformSpeed = 3f;
    private bool _stopPlatformSpawnner;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * _platformSpeed * Time.deltaTime);
        
        StartCoroutine(PlatformSpawnner());

    }

    IEnumerator PlatformSpawnner()
    {
        while (_stopPlatformSpawnner == false)
        {
            Vector3 posToSpawn = new Vector3(0, -0.2f, 37.9f);
            Instantiate(this, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

}
