using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void Harm() // Cuando una pompa toca al jugador.
    {
        GameManager.Instance.OnPlayerFail(gameObject);
    }
}
