using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Blowup : MonoBehaviour
{
    public float impulso_pompa = 2f;
    public float impulso_division = 30f;
    public Vector3 destroy_size = new Vector3(0.5f,0.5f,0.5f);
    public GameObject Pompa;
    public float division_ratio = 2f;
    void Start()
    {
       GameManager.Instance.OnBubbleCreated();
       gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(impulso_pompa, impulso_pompa);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Burst()
    {
        if (gameObject.transform.localScale.magnitude > destroy_size.magnitude)
        {
            PompaSplit();

        }
        GameManager.Instance.OnBubbleDamaged();
        Destroy(gameObject);

    }
     void PompaSplit()
    {
        GameObject Pompa1 = Instantiate(Pompa, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
        GameObject Pompa2 = Instantiate(Pompa, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
        Pompa1.transform.localScale /= division_ratio;
        Pompa2.transform.localScale /= division_ratio;


        Pompa1.GetComponent<Rigidbody2D>().velocity = new Vector2(-impulso_division, impulso_division);
        Pompa2.GetComponent<Rigidbody2D>().velocity = new Vector2(impulso_division, impulso_division);
        Debug.Log("impulso de división efectuado");




    }
}