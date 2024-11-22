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
    private Vector3 nuevaPos;
    public Animator playeranim;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        playeranim = GetComponentInChildren<Animator>();
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
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
                    spriteRenderer.flipX = true;    //voltea al personaje            
                    playeranim.SetBool("Walk", true);
                    nuevaPos = new Vector3 (nuevaPos.x, nuevaPos.y, nuevaPos.z);
                    transform.position = nuevaPos;
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                nuevaPos = transform.position + (Vector3.right * velocity * Time.deltaTime);
                if (nuevaPos.x < borderlimit)
                {
                    spriteRenderer.flipX = false;
                    playeranim.SetBool("Walk", true);
                    nuevaPos = new Vector3(nuevaPos.x, nuevaPos.y, nuevaPos.z);
                    transform.position = nuevaPos;
                }
                
            }
            else playeranim.SetBool("Walk", false);
        //SPAWNEO DE LA BALA
        if (Input.GetKeyDown(KeyCode.Space) && bala_existente == null)
            {
            Debug.Log("controles funcionando");
            playeranim.SetTrigger("Shoot");
            Instantiate(Bala, transform.position, Quaternion.identity);

            }


    }

}
