using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Originator : MonoBehaviour
{
    public Memento Save()
    {
        //Player & inventory
        return new Memento(PlayerController.instance.transform, InventoryManager.instance.pokemonInventory);
    }

    public void Restore(Memento memento)
    {
        //Player
        PlayerController.instance.transform.position = new Vector3(memento.x, memento.y, memento.z);
        
        //Inventory
        InventoryManager.instance.pokemonInventory.Clear();
        InventoryManager.instance.pokemonInventory = memento.PokemonInventory.ToList();
    }
}
