using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI textGame;
    [SerializeField] private float baseTimer = 3;
    private float timer;
    private bool activateTimer;
    
    public static UiManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activateTimer)
        {
            timer -= Time.deltaTime * 1;
            if (timer < 0)
            {
                activateTimer = false;
                textGame.text = "";
            }
        }
    }

    public void ChangeTextGame()
    {
        activateTimer = true;
        timer = baseTimer;
    }
}
