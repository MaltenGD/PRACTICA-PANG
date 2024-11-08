using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(this);
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

<<<<<<< Updated upstream
    public void PompaAnalizer(int pompas_existentes)
    { 
        if (pompas_existentes == 0)
=======
    public void PompaAnalizer(int cantidad)
    {

        if (cantidad == 0)
>>>>>>> Stashed changes
        {
            UIManager.Instance.Inform("Has ganado!");
        }

    }

}
