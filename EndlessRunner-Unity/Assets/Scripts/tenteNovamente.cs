using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tenteNovamente : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    public void Novamente(){
		  SceneManager.LoadScene ("Game_test");
    } 

    public void Sair(){
		  SceneManager.LoadScene ("gameMenu");
    }
}
