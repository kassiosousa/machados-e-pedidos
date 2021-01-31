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

    public void OnCollisionEnter(Collision obj)
    {
        print("=============>");
        if (obj.gameObject.CompareTag("Objectin"))
        {
            //Gameover por bater em objeto indestrutivel
            print("IN");
            gameManager.GameOver();
        }
        else if (obj.gameObject.CompareTag("Objectd"))
        {
            //Remove ponto por bater em objeto destrutivel
            print("DE");
            gameManager.pointsScript.SubEstrela();
        }
    }

}
