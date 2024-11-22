using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmful : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)  // Termina el juego si una pompa toca al jugador .
    {
        
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().Harm();
            Destroy(gameObject);
        }
    }
}