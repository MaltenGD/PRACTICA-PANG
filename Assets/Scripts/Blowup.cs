using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Blowup : MonoBehaviour
{
    public float impulso_inicial = 2f;
    public float impulso_division = 3f;
    public Vector3 initial_size = new Vector3(3.50f, 4.20f, 3.50f);
    public Vector3 destroy_size = new Vector3(0.5f,0.5f,0.5f);
    public GameObject Pompa;
    public float division_ratio = 2f;

    void Start()
    {
        Debug.Log(gameObject.transform.localScale);
       if (gameObject.transform.localScale == initial_size) // Aplica un impulso a las pompas iniciales.
        {

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(impulso_inicial, impulso_inicial);
        }

    }
    public void Burst()
    {
            if (gameObject.transform.localScale.magnitude > destroy_size.magnitude)
            {
                PompaSplit(); // Las pompas se dividen.

            }
            Destroy(gameObject);
            GameManager.Instance.PompaAnalizer();
    }
    void PompaSplit()
    {
        GameObject Pompa1 = Instantiate(Pompa, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
        GameObject Pompa2 = Instantiate(Pompa, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
        Pompa1.transform.localScale /= division_ratio;
        Pompa2.transform.localScale /= division_ratio;

        // Aplica un impulso a las pompas divididas.
        Pompa1.GetComponent<Rigidbody2D>().velocity = new Vector2(-impulso_division, impulso_division);
        Pompa2.GetComponent<Rigidbody2D>().velocity = new Vector2(impulso_division, impulso_division);
    }
}