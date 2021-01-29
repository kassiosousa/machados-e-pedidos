using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    public Vector3 vel;
    public float altura;
    public float limitReposition = -20.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vel * Time.deltaTime);
        if (transform.position.z < limitReposition)
        {
            float repos = 120.0f - (limitReposition - transform.position.z);
            transform.position = new Vector3(0.0f, altura, repos);
        }
    }
}
