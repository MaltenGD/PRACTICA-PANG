using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text texto;
    [SerializeField]
    Text TimerText;
    [SerializeField]
    Text Record;


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

    void Start()
    {
        int record = GameManager.Instance.newbest;
        if (record != 0) //Si hay un récord registrado en el juego.
        Record.text = $"Record de tiempo: {record} segundos";
        else Record.text = $"Record de tiempo: No existe record registrado";
    }
    public void EndInform(string mensage)
    {
        texto.text = mensage;
    
    }
    public void TimerDisplay(float[] timer)
    {
        TimerText.text = timer[1] + ":" + Math.Round(timer[0]); // Creación del temporizador.
    }


}
