using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerBehaviour : MonoBehaviour
{

    public float velocity = 1f;
    [SerializeField] private GameObject bala_existente;
    [SerializeField] private GameObject Bala;
    public float bulletvel = 15f;
    public const float borderlimit = 7.25f;
    [SerializeField] private Vector3 nuevaPos;
    private Animator animator;
    [SerializeField] private bool Moving;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        nuevaPos.y = -4;
    }


    void Update()
    {
        PlayerAction();
    }
    private void PlayerAction()
    {
        //MOVIMIENTO DEL JUGADOR
        
        if (Input.GetKey(KeyCode.A))
        {
            Moving = true;
            nuevaPos = transform.position + (Vector3.left * velocity * Time.deltaTime);
            if (nuevaPos.x > -borderlimit)
            {
                nuevaPos = new Vector3(nuevaPos.x, nuevaPos.y, nuevaPos.z);
                transform.position = nuevaPos;
            }
        }
        else
        Moving = false;
        if (Input.GetKey(KeyCode.D))
        {
            Moving = true;
            nuevaPos = transform.position + (Vector3.right * velocity * Time.deltaTime);
            if (nuevaPos.x < borderlimit)
            {
                nuevaPos = new Vector3(nuevaPos.x, nuevaPos.y, nuevaPos.z);
                transform.position = nuevaPos;
            }

        }
        else
        Moving = false;


        //SPAWNEO DE LA BALA
        if (Input.GetKeyDown(KeyCode.Space) && bala_existente == null)
        {
            Debug.Log("controles funcionando");
            Instantiate(Bala, transform.position, Quaternion.identity);
            animator.SetTrigger("Shoot");
        }

        //La animaci�n del jugador
        if (Moving) animator.SetBool("Run", true);
        else animator.SetBool("Run", false);

    }
}
