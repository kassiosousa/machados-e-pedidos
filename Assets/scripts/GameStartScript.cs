using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManagerScript gameManager;
    void Awake()
    {
        Time.timeScale = 1;
        gameManager = GameManagerScript.instance;
        PlayerPrefs.SetInt("stars", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
