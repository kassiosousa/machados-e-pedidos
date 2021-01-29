using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float vel;
    private Rigidbody rig;
    

    public float[] positions;

    private bool isMoving = false;
    private Vector3 destination;

    public UnityEvent OnJump;

    // responsavel por guardar o estado atual
    private PositionState currentState;

    // lista de inteiros
    public enum PositionState
    {
        left,
        middle,
        right,
    }

    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        currentState = PositionState.middle;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && !isMoving)
        {
            // transform.Translate(Vector3.left * Time.deltaTime * vel);
            switch (currentState)
            {
                case PositionState.left:
                    break;
                case PositionState.right:
                    currentState = PositionState.middle;
                    
                    // cetar a posição do meio
                    break;
                case PositionState.middle:
                    currentState = PositionState.left;
                    // posição para a esquerda
                    break;
                default:
                    break;
            }
            //transform.position = new Vector3(positions[(int)currentState], 0, 0);
            MovetoLine(new Vector3(positions[(int)currentState], 0, 0));
        }

        if(Input.GetKey(KeyCode.D) && !isMoving)
        {
            // transform.Translate(Vector3.right * Time.deltaTime * vel);
            switch (currentState)
            {
                case PositionState.left:
                    currentState = PositionState.middle;
                    break;
                case PositionState.right:
                    break;
                case PositionState.middle:
                    currentState = PositionState.right;
                    break;
                default:
                    break;
            }
            //transform.position = new Vector3(positions[(int)currentState], 0, 0);
            MovetoLine(new Vector3(positions[(int)currentState], 0, 0));
        }  
        
        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * vel);
            // distance = esse metodo dis qual a distancia entre dois pontos
            if (Vector3.Distance(transform.position, destination) < 0.01f)
            {
                isMoving = false;
            }
        }


        if(Input.GetButtonDown("Jump"))
        {
            OnJump.Invoke();
        }
    }

    void MovetoLine(Vector3 dest)
    {
        destination = dest;
        isMoving = true;
    }
}



