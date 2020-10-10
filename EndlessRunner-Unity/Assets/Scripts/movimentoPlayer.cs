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
    private float pistaAtual = 3.0f;
    private Vector3 posicaoAlvoVertical;
    public float velocidadePista;

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
                mudarPista(2); 
                //StartCoroutine(movementoDireto());
               
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                mudarPista(-2);
                //StartCoroutine(movimentoEsquerdo());
                
                
            } 
                //Vector3 posicaoAlvo = new Vector3(posicaoAlvoVertical.x,posicaoAlvoVertical.y, transform.position.z);
                //transform.position = Vector3.MoveTowards(transform.position,posicaoAlvo, velocidadePista * Time.deltaTime);
        }

        else{
            velocidadePulo -= gravidade;
        }

        direction.y = velocidadePulo;
        controle.Move(direction * Time.deltaTime);
    } 

    IEnumerator movimentoEsquerdo()
    {
        Vector3 esquerdo = new Vector3(-0.5f,0,0);
        for(float i = 0; i < 2; i += 0.2f)
        {
            controle.Move(esquerdo * Time.deltaTime * velocidadeHorizontal);
            yield return null;
        } 

    }

    IEnumerator movementoDireto()
    {
        Vector3 direito = new Vector3(0.5f,0,0);
        for(float i = 0; i < 2; i += 0.2f)
        {
            controle.Move(direito * Time.deltaTime * velocidadeHorizontal);
            yield return null;
        }
    } 

   void mudarPista(int sentido){
       float pistaAlvo = pistaAtual + sentido;
       if(pistaAlvo < 0.5f || pistaAlvo > 5.0f){
           return;
       }
       
       pistaAtual = pistaAlvo;
       //posicaoAlvoVertical = new Vector3(pistaAtual, 0.25209140f, 0);
       //controle.Move(posicaoAlvoVertical);*/
       float alvo;
       Vector3 esquerdo = new Vector3(-1,0,0);
       Vector3 direito = new Vector3(1,0,0);
       if(sentido > 0){
            while(transform.position.x < pistaAlvo){ 
           controle.Move(direito * Time.deltaTime * velocidadeHorizontal);
       } 
       }
       else if(sentido < 0) {
          while(transform.position.x > pistaAlvo){ 
           controle.Move(esquerdo * Time.deltaTime * velocidadeHorizontal);
       } 
       }
      

       
   }
}
