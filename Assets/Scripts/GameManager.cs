using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

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


    /* public void RestarVida(int da�o) // Lo descarto ya que no se pide en la pr�ctica
    {
        vida -= da�o;
        Debug.Log(vida);
    } */
    public void OnPlayerDamaged(GameObject jugador)
    {
        Destroy(jugador);
        Debug.Log("Intentando hacer print de derrota");
        UIManager.Instance.Inform("Has Perdido");
        
    }

    public void PompaAnalizer(int pompas_existentes)
    { 
        if (pompas_existentes == 0)
        {
            UIManager.Instance.Inform("Has ganado!");
        }

    }

}
