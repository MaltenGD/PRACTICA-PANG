using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{

    [SerializeField]
    GameObject MenuButton;
    public static ButtonLogic Instance { get; private set; }

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
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void ButtonState(GameObject button, bool state) 
    //{
    //    button.SetActive(state);
    //}
    public void MenuButtonState(bool state)
    {
        MenuButton.SetActive(state);
    }
}
