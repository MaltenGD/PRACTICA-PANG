using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmful : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)  // Termina el juego si una pompa toca al jugador 
    {
        if (collision.GetComponent<Health>() != null)
        {
            GameManager.Instance.OnPlayerDamaged(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
