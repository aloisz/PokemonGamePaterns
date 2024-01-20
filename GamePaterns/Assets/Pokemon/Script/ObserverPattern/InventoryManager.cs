using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Action<int, int, string> OnCombatWithEntities; // observer
    public int gold;
    public int nbrPokeball;
    public string PokemonName;
    public List<string> pokemonInventory;

    public static InventoryManager instance;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // initialize the observer pattern
        FightWithEntities(0, 0, String.Empty);
    }

    public void FightWithEntities(int goldEarned, int nbrOfPokeball, string NameOfThePokemon)
    {
        gold += goldEarned;
        nbrPokeball -= nbrOfPokeball;
        if (NameOfThePokemon != String.Empty)
        {
            PokemonName = (NameOfThePokemon);
            pokemonInventory.Add(PokemonName);
        }
        OnCombatWithEntities?.Invoke(gold, nbrPokeball, PokemonName);
    }
}
