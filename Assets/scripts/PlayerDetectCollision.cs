using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Objectin"))
        {
            GameOverPoints();
        }
        else if (obj.gameObject.CompareTag("Objectd"))
        {
            RemovePoints();
        }
    }


    public void GameOverPoints()
    {
       Debug.Log("Colisao!!");
    }


    public void RemovePoints()
    {
        //TODO
    }

}
