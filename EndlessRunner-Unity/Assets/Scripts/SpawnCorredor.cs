using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
            Transform corr = Instantiate(corredores[i], new Vector3(2.82f, -0.08f, tamanho += 66.8f), transform.rotation).transform;
            corredoresInst.Add(corr);
            offset += 66.8f;
        }

        posicaoCorredorAtual = corredoresInst[corredorIndex].GetComponentInChildren<pontoFinalScript>().pontoFinal;//pega a posição através do componente pontoFinal do script de ponto final da instância de um corredor

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

            posicaoCorredorAtual = corredoresInst[corredorIndex].GetComponentInChildren<pontoFinalScript>().pontoFinal;

        }
    }

    public void respawnCorredor(GameObject corredor)
    {
        corredor.transform.position = new Vector3(2.82f, -0.08f, offset);
        offset += 66.84f;
    }//2.82 -0.081 23.96 container 1 <-| container 2 -> 3.05 0.177 -43.351 container 3 -> 2.83 -.0.06 90.53
    //position the first container should be 2.82 -0.06 -42.87
    //position of the pivot 2.79 -0.006 -42.828
}
