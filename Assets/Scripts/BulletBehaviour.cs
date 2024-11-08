using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{

    private Vector3 nuevaPos;
    public float bulletvel = 20;
    private float rooflimit = 4;
    public Blowup BlowupScript;


    void Start()
    { 
    
    }
    void Update()
    {

        nuevaPos = transform.position + (Vector3.up * bulletvel * Time.deltaTime);
        if (nuevaPos.y < rooflimit)
        {
            nuevaPos = new Vector3(nuevaPos.x, nuevaPos.y, nuevaPos.z);
            transform.position = nuevaPos;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Blowup>() != null)
        {
            BlowupScript = collision.gameObject.GetComponent<Blowup>();
            BlowupScript.Burst();
            Destroy(gameObject);
        }



    }

}

