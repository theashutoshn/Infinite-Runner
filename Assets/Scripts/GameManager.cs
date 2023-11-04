using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GamePause();
    }

    public void GamePause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
        }
    }
}
