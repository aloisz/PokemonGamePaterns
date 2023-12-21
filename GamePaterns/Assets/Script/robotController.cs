using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotController : Actor2
{

    public override void MoveStraight()
    {
        transform.position += new Vector3(1f, 0f, 0f);
    }
    public override void TurnLeft()
    {

        //transform.rotation = ...
    }
}
