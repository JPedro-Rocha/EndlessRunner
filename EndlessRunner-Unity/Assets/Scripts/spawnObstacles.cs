using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{
    public GameObject[] obstaculos;//prefabs
    public Vector2 numeroDeObstaculos;//valor mínimo e máximo para sortear o número de obstáculos a serem instanciados
    public List<GameObject> novoObstaculo;//instancia do obstáculo

    void Start()//instanciar os obstaculos primeiro e depois ativar eles na posição certa, e reciclar depois de o jogador passar por ele
    {
        int novoNumeroDeObstaculos = (int)Random.Range(numeroDeObstaculos.x, numeroDeObstaculos.y);//tirando o número de obsáculos a ser instanciado

        for (int i = 0; i < novoNumeroDeObstaculos; i++)
        {
            novoObstaculo.Add(Instantiate(obstaculos[Random.Range(0, obstaculos.Length)], transform));//qual obstáculo é selecionado é escolhio randomicamente
            novoObstaculo[i].SetActive(false);
        }

        posicionarObstaculos();
    }

    void Update()
    {

    }

    void posicionarObstaculos() //current character position 2.8 0.189
    {
        Debug.Log("Oh hi Mark");
        for (int i = 0; i < novoObstaculo.Count; i++)
        {
            float posZMin = -40.42f;//(66.84f / novoObstaculo.Count) + (66.84f / novoObstaculo.Count) * i;
            float posZMax = 20.42f;//(66.84f / novoObstaculo.Count) + (66.84f / novoObstaculo.Count) * i + 1;
            novoObstaculo[i].transform.localPosition = new Vector3(0, 0.45f, Random.Range(posZMin, posZMax));
            novoObstaculo[i].SetActive(true);
        }
    }
}

