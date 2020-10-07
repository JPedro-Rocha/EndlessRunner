using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPlayer : MonoBehaviour
{
    private CharacterController controle;
    public float velocidade;
    public float alturaPulo;
    private float velocidadePulo;
    public float gravidade;

    // Start is called before the first frame update
    void Start()
    {
        controle = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward * velocidade;
        if(controle.isGrounded){

            if(Input.GetKeyDown(KeyCode.Space)){
                velocidadePulo = alturaPulo;
            }
        }

        else{
            velocidadePulo -= gravidade;
        }

        direction.y = velocidadePulo;
        controle.Move(direction * Time.deltaTime);
    } 
}
