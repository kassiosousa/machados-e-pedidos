using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    // Status da porta
    // Nada = Continua transparente
    // Aguardando = Fica amarela
    // Pronta = Fica azul
    // Acertada = fica verde por 4 seg

    // Tag da area do machado = AxeArea
    // Tag da porta = Door

    

    // lista de cores
    public Color corPadrao = Color.white;
    public Color corAguardando = Color.yellow;
    public Color CorPronto = Color.blue;
    public Color corEntregue = Color.green;

    [Range(0,1)]
    // Propabilidade de interação da porta(porcentagem entre 0/1)
    public float InteractionPossibity;
    // flag/ utilizado para saber se é interativo ou não
    private bool isInteractable;
    // flag usada para saber se pode receber o pedido
    public bool Receving = false;

 
  
    // Variavel responsavel por cetar o objeto
    Material materialObjeto;

    void Start()
    {
       materialObjeto = GetComponent<MeshRenderer>().material;
       ResetDoor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "AxeArea" && isInteractable)
        {
            Debug.Log("Trocou de cor");

            materialObjeto.color = CorPronto;
            Receving = true;

        }
    }

    public void ResetDoor()
    {
        
        float chance = Random.Range(0f, 1f);
       // print(chance);
        if(chance < InteractionPossibity)
        { 
            isInteractable = true;
            materialObjeto.color = corAguardando;
        } else
        {
            isInteractable = false;
            materialObjeto.color = corPadrao;
        }
        Receving = false;
    }

    public void CheckDelivery()
    {
        if( Receving == true)
        {
            materialObjeto.color = corEntregue;
        }
    }
}
