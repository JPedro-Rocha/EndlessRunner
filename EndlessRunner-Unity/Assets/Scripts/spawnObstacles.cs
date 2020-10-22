using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spawnObstacles : MonoBehaviour
{
    public NavMeshSurface surface;
    public GameObject[] obstaculos;//prefabs
    public Vector2 numeroDeObstaculos;//valor mínimo e máximo para sortear o número de obstáculos a serem instanciados
    public List<GameObject> novoObstaculo;//instancia do obstáculo
    public GameObject enemy;

    void Start()//instanciar os obstaculos primeiro e depois ativar eles na posição certa, e reciclar depois de o jogador passar por ele
    {
        surface.BuildNavMesh();

        int novoNumeroDeObstaculos = (int)Random.Range(numeroDeObstaculos.x, numeroDeObstaculos.y);//tirando o número de obsáculos a ser instanciado
        for (int i = 0; i < novoNumeroDeObstaculos; i++)
        {
            novoObstaculo.Add(Instantiate(obstaculos[Random.Range(0, obstaculos.Length)], transform));//qual obstáculo é selecionado é escolhio randomicamente
            novoObstaculo[i].SetActive(false);
        }

        //instancia o inimigo com a AI
        Instantiate(enemy, transform);
        enemy.SetActive(false);
        posicionarObstaculos();
    }

    void Update()
    {

    }

    void posicionarObstaculos() //current character position 2.8 0.189
    {
        float posZMin = -40.42f;//(66.84f / novoObstaculo.Count) + (66.84f / novoObstaculo.Count) * i;
        float posZMax = 20.42f;//(66.84f / novoObstaculo.Count) + (66.84f / novoObstaculo.Count) * i + 1;

        enemy.transform.localPosition = new Vector3(2.79f, 1.17f, Random.Range(posZMin, posZMax)); Debug.Log("HI");
        enemy.SetActive(true);

        for (int i = 0; i < novoObstaculo.Count; i++)
        {


            //novoObstaculo[i].transform.localPosition = new Vector3(0, 0.35f, Random.Range(posZMin, posZMax));
            //novoObstaculo[i].SetActive(true);

            float[] posXBarril = { 0.67f, 2.79f, 4.9f };

            float[] posXConsole = { 0.673f, 2.778f, 4.874f };

            float[] posYBarras = { 0.18f, -2.31f };

            float[] posXProjetor = { 1.9f, 4.67f };

            if (novoObstaculo[i].tag == "Barril")
            {
                novoObstaculo[i].transform.localPosition = new Vector3(posXBarril[Random.Range(0, posXBarril.Length)],
                                                                         -0.18f, Random.Range(posZMin, posZMax));
                novoObstaculo[i].SetActive(true);
            }

            else if (novoObstaculo[i].tag == "Console")
            {
                novoObstaculo[i].transform.localPosition = new Vector3(posXConsole[Random.Range(0, posXConsole.Length)],
                                                                         0.477f, Random.Range(posZMin, posZMax));
                novoObstaculo[i].SetActive(true);
            }

            else if (novoObstaculo[i].tag == "Barras")
            {
                novoObstaculo[i].transform.localPosition = new Vector3(4.35f,
                                         posYBarras[Random.Range(0, posYBarras.Length)], Random.Range(posZMin, posZMax));
                novoObstaculo[i].SetActive(true);
            }

            else if (novoObstaculo[i].tag == "Projetor")
            {
                novoObstaculo[i].transform.localPosition = new Vector3(posXProjetor[Random.Range(0, posXProjetor.Length)],
                                                                         -0.22f, Random.Range(posZMin, posZMax));
                novoObstaculo[i].SetActive(true);
            }
        }
    }
}

