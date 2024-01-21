using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

[Serializable]
public class Memento
{
    public float x;
    public float y;
    public float z;
    
    [SerializeField] public string[] PokemonInventory;
    
    // Constructor
    public Memento(Transform playerTransform, List<string> pokemonInventory)
    {
        this.x = playerTransform.transform.position.x;
        this.y = playerTransform.transform.position.y;
        this.z = playerTransform.transform.position.z;

        this.PokemonInventory = pokemonInventory.ToArray();
    }
}

