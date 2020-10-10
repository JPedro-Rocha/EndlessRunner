using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorredor : MonoBehaviour
{
    //[22.29]tamanho de uma corredor pequeno  [66.84]tamanho corredor grande
    public List<GameObject> corredores = new List<GameObject>();
    public int offset;
    private float tamanho = -66.8f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < corredores.Count; i++)
        {
            Instantiate(corredores[i], new Vector3(0, 0, tamanho += 66.8f), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void respawnCorredor()
    {

    }
}
