using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimentoPlayer : MonoBehaviour
{
    //private CharacterController controle;
    private BoxCollider collider;
    public float velocidade;
    public float alturaPulo;
    private float velocidadePulo;
    public float gravidade;
    public float velocidadeHorizontal;
    private float pistaAtual = 2.8f;
    private Vector3 posicaoAlvoVertical = new Vector3(2.8f,0.4f, 0);
    public float velocidadePista;
    public Animator animator;
    public bool agachado = false;

    public float speed;
    public Rigidbody body;
    public float puloAltura;
    public float puloDistancia;
    private bool jump = false;
    private float comecoPulo;
    public bool morto = false;

    // Start is called before the first frame update
    void Start()
    {
        //controle = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
   /* void Update()
    {
        Vector3 direction = Vector3.forward * velocidade;
        if (controle.isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadePulo = alturaPulo;
                animator.SetBool("JumpControl", true);
                jump = true;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("agachado", true);
                agachado = true;
                controle.height = 1.04f;
                controle.center = new Vector3(0,0.21f,0.48f);
            }else{
                animator.SetBool("agachado", false);
                controle.height = 1.48f;
                controle.center = new Vector3(0,0.34f,0.48f);
                agachado = false;
                
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                mudarPista(2);
                //StartCoroutine(movementoDireto());

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                mudarPista(-2);
                //StartCoroutine(movimentoEsquerdo());


            }
            //Vector3 posicaoAlvo = new Vector3(posicaoAlvoVertical.x,posicaoAlvoVertical.y, transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position,posicaoAlvo, velocidadePista * Time.deltaTime);
        }

        else
        {
            velocidadePulo -= gravidade;
            animator.SetBool("JumpControl", false);
        }


        direction.y = velocidadePulo;
        controle.Move(direction * Time.deltaTime);
    }*/ 

    void Update(){

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //velocidadePulo = alturaPulo;
            //body.velocity = Vector3.up * speed;
            pulo();
            animator.SetBool("JumpControl", true);
            //jump = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            mudarPista(2);
        } 

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mudarPista(-2);
        } 

        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("agachado", true);
            agachado = true;
            collider.center = new Vector3( 0, 0.13f, 0.47f);
            collider.size = new Vector3( 0.89f, 0.9f, 0.61f);

            //controle.height = 1.04f;
            //controle.center = new Vector3(0,0.21f,0.48f);
        }else{
            animator.SetBool("agachado", false);
            agachado = false;
            collider.center = new Vector3( 0, 0.42f, 0.47f);
            collider.size = new Vector3(0.89f , 1.51f, 0.61f);
            
                
        }

        if(jump){
            float ratio = (transform.position.z - comecoPulo) / puloDistancia;
            float temp;
            if(ratio >= 1f){
                jump = false;
                animator.SetBool("JumpControl", false);
                //desabilitar animator
            }else{
                temp = Mathf.Sin(ratio * Mathf.PI) * alturaPulo;

                if(temp > 0.4f){
                    posicaoAlvoVertical.y = temp;
                    //animator.SetBool("JumpControl", false);
                }
                
            }
        }else{
            posicaoAlvoVertical.y = Mathf.MoveTowards( posicaoAlvoVertical.y, 0.4f, 5 * Time.deltaTime);
        }

        Vector3 posicaoAlvo = new Vector3(posicaoAlvoVertical.x,posicaoAlvoVertical.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position,posicaoAlvo, velocidadePista * Time.deltaTime);
    }

    private void FixedUpdate(){
        body.velocity = Vector3.forward * speed;
    } 

    private void pulo(){

        if(!jump){
            comecoPulo = transform.position.z;
            //animator pulo
            //animator spped do pulo
            jump = true;
        }
    }

    void mudarPista(int sentido)
    {
        float pistaAlvo = pistaAtual + sentido;
        if (pistaAlvo < 0.7f || pistaAlvo > 4.8f)
        {
            return;
        }

        pistaAtual = pistaAlvo;
        posicaoAlvoVertical = new Vector3(pistaAtual,0.4f, 0);
        //controle.Move(posicaoAlvoVertical);
        /*float alvo;
        Vector3 esquerdo = new Vector3(-1, 0, 0);
        Vector3 direito = new Vector3(1, 0, 0);
        if (sentido > 0)
        {
            while (transform.position.x < pistaAlvo)
            {
                controle.Move(direito * Time.deltaTime * velocidadeHorizontal);
            }
        }
        else if (sentido < 0)
        {
            while (transform.position.x > pistaAlvo)
            {
                controle.Move(esquerdo * Time.deltaTime * velocidadeHorizontal);
            }
        }*/
    }

    void OnCollisionEnter(Collision col)
    {
        //speed = 0;
        if(col.gameObject.tag.Equals("Console") || col.gameObject.tag.Equals("Projetor") 
            || col.gameObject.tag.Equals("Barras") || col.gameObject.tag.Equals("Barril") ){
                
            speed = 0;
            velocidadeHorizontal = 0;
            velocidadePista = 0;
            alturaPulo = 0;
            Destroy(col.gameObject);
            morto = true;
            animator.SetBool("morte", true);
            Invoke("gameOver",1f);
        }
    }

    void gameOver(){
        SceneManager.LoadScene ("GameOver");
    }

   /* IEnumerator movimentoEsquerdo()
    {
        Vector3 esquerdo = new Vector3(-0.5f, 0, 0);
        for (float i = 0; i < 2; i += 0.2f)
        {
            controle.Move(esquerdo * Time.deltaTime * velocidadeHorizontal);
            yield return null;
        }

    }*

    IEnumerator movementoDireto()
    {
        Vector3 direito = new Vector3(0.5f, 0, 0);
        for (float i = 0; i < 2; i += 0.2f)
        {
            controle.Move(direito * Time.deltaTime * velocidadeHorizontal);
            yield return null;
        }
    }

    void mudarPista(int sentido)
    {
        float pistaAlvo = pistaAtual + sentido;
        if (pistaAlvo < 0.5f || pistaAlvo > 5.0f)
        {
            return;
        }

        pistaAtual = pistaAlvo;
        //posicaoAlvoVertical = new Vector3(pistaAtual, 0.25209140f, 0);
        //controle.Move(posicaoAlvoVertical);
        float alvo;
        Vector3 esquerdo = new Vector3(-1, 0, 0);
        Vector3 direito = new Vector3(1, 0, 0);
        if (sentido > 0)
        {
            while (transform.position.x < pistaAlvo)
            {
                controle.Move(direito * Time.deltaTime * velocidadeHorizontal);
            }
        }
        else if (sentido < 0)
        {
            while (transform.position.x > pistaAlvo)
            {
                controle.Move(esquerdo * Time.deltaTime * velocidadeHorizontal);
            }
        }
    }

    */
}
