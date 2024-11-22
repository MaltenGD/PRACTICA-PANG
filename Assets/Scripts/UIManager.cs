using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    TextMeshProUGUI texto;
    public static UIManager Instance { get; private set; }
    [SerializeField]
    private float fps = 0f;
    private float seconds = 0f;
    private float minutes = 0f;
    private bool findeljuego = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }


    void Update()
    {
        fps += Time.deltaTime;
        if (fps >= 1f)
        {
            if (!findeljuego)
            {
                fps = 0f;
                seconds += 1f;
                Debug.Log("Segundos: " + seconds);
                Debug.Log("Minutos: " + minutes);
            }
        }
        if (seconds == 60f)
        {
            if (!findeljuego)
            {
                seconds = 0f;
                minutes += 1f;
                Debug.Log("Segundos: " + seconds);
                Debug.Log("Minutos: " + minutes);
            }
        }
    }

    public void Inform(string mensage)
    {
        findeljuego = true;
    }

}
