using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public Timer TimerScript;
    public string ActualScene;
    public int newbest = 0;


    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        FetchTimerScript();
    }
    public void PompaAnalizer()
    {
        var Pompas_existentes = GameObject.FindObjectsOfType<Blowup>();
        Debug.Log($"Pompas existentes: {Pompas_existentes.Length - 1}"); // No s� por qu� cuenta 1 posicion de m�s en el length.
        if (Pompas_existentes.Length - 1 == 0) // Cuando no queden pompas en la pantalla.
        {
            OnVictory();
        }

    }

    /* public void RestarVida(int da�o) // Lo descarto ya que no se pide en la pr�ctica.
    {
        vida -= da�o;
        Debug.Log(vida);
    } */
    public void OnPlayerFail(GameObject jugador) // Al perder la partida.
    {
        TimerScript.TimerState(false); // Detiene el temporizador.
        Destroy(jugador);
        UIManager.Instance.EndInform("Has Perdido"); // El texto del canvas del juego cambia a "Has perdido"
        ButtonLogic.Instance.MenuButtonState(true); // Activa el bot�n de regreso al men� principal.
    }


    public void OnVictory() // Al ganar la partida.
    {
        TimerScript.TimerState(false); // Detiene el temporizador.
        TimerScript.SendScoreToGM();
        UIManager.Instance.EndInform("�Has ganado!"); // El texto del canvas del juego cambia a "�Has ganado!"
        ButtonLogic.Instance.MenuButtonState(true); // Activa el bot�n de regreso al men� principal.
    }

    public void FetchTimerScript()
    {
        TimerScript = gameObject.GetComponent<Timer>();
    }
    public void storeNewBest(float[] timerscore)
    {
        int Scoresecs = Convert.ToInt32(timerscore[0] + (timerscore[1] * 60));
        if (newbest > Scoresecs || newbest == 0) 
            //Si el mejor tiempo es 0 (es decir, si nadie ha ganado el nivel a�n) o
            //el tiempo de la partida actual es menor al tiempo r�cord, el nuevo r�cord
            //cambia por el valor de la partida jugada.
        {
            newbest = Scoresecs;
        }
    }

}
