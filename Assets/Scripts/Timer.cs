using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    public bool isTimerActive = false;
    public float[] timercount = new float[2]; // la pos 0 del array determina los segundos (Truncados) la pos 1 son los minutos
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      if (isTimerActive)
        {
         timercount[0] += Time.deltaTime;

            if (timercount[0] >= 60)
            {
                timercount[0] = 0;
                timercount[1]++;
            }
            UIManager.Instance.TimerDisplay(timercount);
        }
    }
    public void TimerState(bool state)
    {
        isTimerActive = state;
    }
    public void ClearTimer()
    {
        timercount[1] = 0; timercount[0]= 0; 
    }
    public void SendScoreToGM()
    {
        GameManager.Instance.storeNewBest(timercount);
    }

}
