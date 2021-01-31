using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDetectColission : MonoBehaviour
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
            // CameraShake();
        } 
        else if (obj.gameObject.CompareTag("Objectd"))
        {
            Destroy(obj.gameObject);
        }
    }


    /* Qual a diferença entre esse metodo e OnCollisionEnter?!?!
    
    public void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
        }
    }
    */



}