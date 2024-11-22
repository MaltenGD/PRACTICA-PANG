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
    void Update()
    {

    }
    public void PompaAnalizer()
    {
        var Pompas_existentes = GameObject.FindObjectsOfType<Blowup>();
        Debug.Log($"Pompas existentes: {Pompas_existentes.Length - 1}"); // no se por que cuenta 1 posicion de más en el length
        if (Pompas_existentes.Length - 1 == 0)

        {
            OnVictory();
        }

    }

    /* public void RestarVida(int daño) // Lo descarto ya que no se pide en la práctica
    {
        vida -= daño;
        Debug.Log(vida);
    } */
    public void OnPlayerFail(GameObject jugador)
    {
        TimerScript.TimerState(false);
        Destroy(jugador);
        Debug.Log("Intentando hacer print de derrota");
        UIManager.Instance.EndInform("Has Perdido");
        ButtonLogic.Instance.MenuButtonState(true);
    }


    public void OnVictory()
    {
        TimerScript.TimerState(false);
        TimerScript.SendScoreToGM();
        UIManager.Instance.EndInform("Has ganado!");
        ButtonLogic.Instance.MenuButtonState(true);
    }

    public void FetchTimerScript()
    {
        TimerScript = gameObject.GetComponent<Timer>();
    }
    public void storeNewBest(float[] timerscore)
    {
        int Scoresecs = Convert.ToInt32(timerscore[0] + (timerscore[1] * 60));
        if (newbest > Scoresecs || newbest == 0)
        {
            newbest = Scoresecs;
        }
    }

}
