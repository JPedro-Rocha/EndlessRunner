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
    public float velocidadeHorizontal;

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

            if(Input.GetKeyDown(KeyCode.RightArrow)){
                StartCoroutine(movementoDireto());
                //direita();
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                 StartCoroutine(movimentoEsquerdo());
                 //esquerda();
            }
        }

        else{
            velocidadePulo -= gravidade;
        }

        direction.y = velocidadePulo;
        controle.Move(direction * Time.deltaTime);
    } 

    IEnumerator movimentoEsquerdo()
    {
        for(float i = 0; i < 2; i += 0.2f)
        {
            controle.Move(Vector3.left * Time.deltaTime * velocidadeHorizontal);
            yield return null;
        } 

    }

    IEnumerator movementoDireto()
    {
          for(float i = 0; i < 2; i += 0.2f)
        {
            controle.Move(Vector3.right * Time.deltaTime * velocidadeHorizontal);
            yield return null;
        }
    } 

    void esquerda(){
        controle.Move(Vector3.left * Time.deltaTime * velocidadeHorizontal);
    }

    void direita(){
         controle.Move(Vector3.right * Time.deltaTime * velocidadeHorizontal);
    }
}
