using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PompaBehaviour : MonoBehaviour
{
    public GameObject Pompa;
    public float impulso_pompa = 3f;
    public int size = 2; // Tamaño inicial de las pompas
    void Awake()
    {
     GameManager.Instance.OnBubbleCreated();
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BulletBehaviour>() != null )
        {
            if (size > 0)
            {
                PompaSplit();

            }
            GameManager.Instance.OnBubbleDamaged();
            Destroy(gameObject);
            

           
                
        }
    }
    void PompaSplit()
    {
            GameObject Pompa1 = Instantiate(Pompa, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
            GameObject Pompa2 = Instantiate(Pompa, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
            Pompa1.transform.localScale /= 2f;
            Pompa2.transform.localScale /= 2f;

            Pompa1.GetComponent<PompaBehaviour>().size -= 1;
            Pompa2.GetComponent<PompaBehaviour>().size -= 1;

            Rigidbody2D rb1 = Pompa1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = Pompa2.GetComponent<Rigidbody2D>();

            rb1.velocity = new Vector2(-impulso_pompa, impulso_pompa);
            rb2.velocity = new Vector2(impulso_pompa, impulso_pompa);


           
    }
}
 