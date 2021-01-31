using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectCollision : MonoBehaviour
{

    private GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManagerScript.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objectin"))
        {
            //Gameover por bater em objeto indestrutivel
            gameManager.GameOver();
        }
        else if (other.gameObject.CompareTag("Objectd"))
        {
            //Remove ponto por bater em objeto destrutivel
            gameManager.CamShake();
            gameManager.pointsScript.SubEstrela();
            other.gameObject.SetActive(false);
        }
    }

}
