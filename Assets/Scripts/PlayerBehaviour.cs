using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerBehaviour : MonoBehaviour
{

    public float velocity = 1f;
    private GameObject bala_existente;
    [SerializeField]    
    private GameObject Bala;
    public float bulletvel = 15f;
    public const float borderlimit = 7.25f;
    public Vector3 nuevaPos;


    void Start()
    {
        nuevaPos.y = -4;
    }


            void Update()
    {
            //MOVIMIENTO DEL JUGADOR
            if (Input.GetKey(KeyCode.A))
            {
                nuevaPos = transform.position + (Vector3.left * velocity * Time.deltaTime);
                if (nuevaPos.x > -borderlimit)
                { 
                    nuevaPos = new Vector3 (nuevaPos.x, nuevaPos.y, nuevaPos.z);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                nuevaPos = transform.position + (Vector3.right * velocity * Time.deltaTime);
                if (nuevaPos.x < borderlimit)
            {
                nuevaPos = new Vector3(nuevaPos.x, nuevaPos.y, nuevaPos.z);
            }
                
            }
            transform.position = nuevaPos;
        //SPAWNEO DE LA BALA
        if (Input.GetKeyDown(KeyCode.Space) && bala_existente == null)
            {
            Debug.Log("controles funcionando");
            bala_existente = Instantiate(Bala, transform.position, Quaternion.identity);

            }

            if (bala_existente != null)
            {
            Debug.Log("bala funcionando");
            bala_existente.transform.Translate(Vector2.up * bulletvel * Time.deltaTime);
            }


    }

}
