using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGrassEntitie : MonoBehaviour
{

    public TallGrass fromWichTallGrassIAm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fromWichTallGrassIAm.Interact(fromWichTallGrassIAm.road);
        }
    }
}
