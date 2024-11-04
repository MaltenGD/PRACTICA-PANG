using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int pompas_existentes = 0;
    public UIManager UIManager;
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


    /* public void RestarVida(int daño) // Lo descarto ya que no se pide en la práctica
    {
        vida -= daño;
        Debug.Log(vida);
    } */
    public void OnPlayerDamaged(GameObject jugador)
    {
        Destroy(jugador);
        Debug.Log("Intentando hacer print de derrota");
        UIManager.Instance.Inform("Has Perdido");
        
    }
    public void OnBubbleCreated() 
    {
        pompas_existentes++;
        
    }
    public void OnBubbleDamaged()
    {
        pompas_existentes--;
        // Evito que salte el texto de victoria antes de tiempo
        if (pompas_existentes == 0)
        {
            UIManager.Instance.Inform("Has ganado!");
        }

    }

}
