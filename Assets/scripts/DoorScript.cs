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
    public Color corErro = Color.red;
    public bool isRight = false;
    public bool isLeft = false;

    [Range(0,1)]
    // Propabilidade de interação da porta(porcentagem entre 0/1)
    public float InteractionPossibity;
    // flag/ utilizado para saber se é interativo ou não
    private bool isInteractable;
    // flag usada para saber se pode receber o pedido
    private bool Receving = false;
    // flag usada para saber se a porta foi acertada
    private bool Received = false;
    private GameManagerScript gameManager;

    // Variavel responsavel por cetar o objeto
    Material materialObjeto;

    void Start()
    {
       gameManager = GameManagerScript.instance;

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

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "AxeArea" && isInteractable && !Received)
        {
            Debug.Log("Porta saiu da área sem ser acertada");
            Debug.Log("Trocou de cor");
            materialObjeto.color = corErro;
            Receving = false;
            // Remove 1 estrela do jogador
            gameManager.pointsScript.SubEstrela();
            gameManager.VerifyGameOver();
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
            Received = true;
            gameManager.pointsScript.AddEstrela();
        }
    }
}
