using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManagerScript gameManager;
    void Start()
    {
        Time.timeScale = 1;
        gameManager = GameManagerScript.instance;
        gameManager.StartRun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
