using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Blowup : MonoBehaviour
{
    public float impulso_pompa = 2f;
    public int size = 2;
    public GameObject Pompa;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(impulso_pompa, impulso_pompa);
        GameManager.Instance.OnBubbleCreated();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Burst()
    {
        if (size > 0)
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
        Pompa1.transform.localScale /= 2f;
        Pompa2.transform.localScale /= 2f;

        Pompa1.GetComponent<Blowup>().size -= 1;
        Pompa2.GetComponent<Blowup>().size -= 1;

        Rigidbody2D rb1 = Pompa1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = Pompa2.GetComponent<Rigidbody2D>();

        rb1.velocity = new Vector2(-impulso_pompa, impulso_pompa);
        rb2.velocity = new Vector2(impulso_pompa, impulso_pompa);
    



      }
}