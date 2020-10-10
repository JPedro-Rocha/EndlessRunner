﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorredor : MonoBehaviour
{
    //[22.29]tamanho de uma corredor pequeno  [66.84]tamanho corredor grande
    public List<GameObject> corredores = new List<GameObject>();//lista dos prefabs de corredores
    public List<Transform> corredoresInst = new List<Transform>();//lista das instâncias de corredores

    private float tamanho = -66.8f;
    public float offset = 0;

    private Transform player;
    private Transform posicaoCorredorAtual;

    private int corredorIndex;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < corredores.Count; i++)
        {
            Transform corr = Instantiate(corredores[i], new Vector3(0, 0, tamanho += 66.8f), transform.rotation).transform;
            corredoresInst.Add(corr);
            offset += 66.8f;
        }

        posicaoCorredorAtual = corredoresInst[corredorIndex].GetComponent<pontoFinalScript>().pontoFinal;//pega a posição através do componente pontoFinal do script de ponto final da instância de um corredor

    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - posicaoCorredorAtual.position.z;//checa a distância do jogador para o ponto final do corredor

        if (distance >= 5)
        {
            respawnCorredor(corredoresInst[corredorIndex].gameObject);
            corredorIndex++;

            if (corredorIndex > corredoresInst.Count - 1)//não deixa o index ir além do que tem na lista
            {
                corredorIndex = 0;
            }

            posicaoCorredorAtual = corredoresInst[corredorIndex].GetComponent<pontoFinalScript>().pontoFinal;

        }
    }

    public void respawnCorredor(GameObject corredor)
    {
        corredor.transform.position = new Vector3(0, 0, offset);
        offset += 66.8f;
    }
}
