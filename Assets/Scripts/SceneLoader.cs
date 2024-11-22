using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneWarper(string escena)
    {
        SceneManager.LoadScene(escena);
        if (escena == "Juego") Timer.Instance.TimerState(true);
        if (escena == "Menu")
        {
           
            Timer.Instance.ClearTimer();
        }
    }
}

