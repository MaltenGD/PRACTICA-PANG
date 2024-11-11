using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    public void ActivateButton()
    {
        gameObject.SetActive(true);
    }

    public void Warp2Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
