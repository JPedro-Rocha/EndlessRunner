using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float recorde;
    public movimentoPlayer jogador;
    public Text recordeTela;
    public AudioClip ambiente;
    public AudioClip morte;
    public int controle = 0;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimentoPlayer>();
        //AudioSource.PlayClipAtPoint(ambiente, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        recorde += Time.deltaTime * 5f;
        
        if(jogador.morto){    
            jogador.speed = 0;
            if(controle == 0){
                AudioSource.PlayClipAtPoint(morte, Camera.main.transform.position);
                controle = 1;
            }
        }else{
            recordeTela.text = Mathf.Round(recorde).ToString();
            jogador.speed = recorde / 10;
        }
    }
}
