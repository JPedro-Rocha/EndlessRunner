using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstaculos : MonoBehaviour
{
    public GameObject[] obstaculos;
    public Vector2 numeroDeObstaculos;
    public List<GameObject> novoObstaculo;
    // Start is called before the first frame update
    void Start()//instanciar os obstaculos primeiro e depois ativar eles na posição certa, e reciclar depois de o jogador passar por ele
    {
        int novoNumeroDeObstaculos = (int)Random.Range(numeroDeObstaculos.x, numeroDeObstaculos.y);

        for (int i = 0; i < novoNumeroDeObstaculos; i++)
        {
            novoObstaculo.Add(Instantiate(obstaculos[Random.Range(0, obstaculos.Length)], transform));
            novoObstaculo[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void posicionarObstaculos()
    {
        for (int i = 0; i < novoObstaculo.Count; i++)
        {
            float posZMin = (66.84f / novoObstaculo.Count) + (66.84f / novoObstaculo.Count) * i;
            float posZMax = (66.84f / novoObstaculo.Count) + (66.84f / novoObstaculo.Count) * i + 1;
            novoObstaculo[i].transform.localPosition = new Vector3(0, 0, Random.Range(posZMin, posZMax));
            novoObstaculo[i].SetActive(true);
        }
    }
}
