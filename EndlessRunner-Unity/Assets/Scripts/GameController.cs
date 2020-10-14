﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float recorde;
    public movimentoPlayer jogador;
    public Text recordeTela;
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimentoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        recorde += Time.deltaTime * 5f;
        
        if(jogador.morto){    
            jogador.speed = 0;
        }else{
            recordeTela.text = Mathf.Round(recorde).ToString();
            jogador.speed = recorde / 10;
        }
    }
}
