using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    public override void MoveStraight()
    {
        transform.position += new Vector3(0f, 0f, 1);
    }
    
    public override void MoveDown()
    {
        transform.position += new Vector3(0f, 0f, -1);
    }
    
    public override void TurnRight()
    {
        transform.position += new Vector3(1, 0f, 0);
    }
    
    public override void TurnLeft()
    {
        transform.position += new Vector3(-1, 0f, 0);
    }
}
