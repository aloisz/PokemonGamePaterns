using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Pokemon;
    
    public static GameManager instance;
    
    private void Awake()
    {
        instance = this;
    }
}
