using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI texto;
    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }


    void Update()
    {
        
    }

    public void Inform(string mensage)
    {
        texto.text = mensage;
    
    }

}
