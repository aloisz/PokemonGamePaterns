
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokemonTeam : MonoBehaviour
{
    public List<PokemonCreator> pokemonCreators;

	void Start ()
    {
        // Create a tree structure
        // Creation de l'inventaire des pokemons 
        Composite inventory = new Composite("Inventory");

        for (int i = 0; i <= pokemonCreators.Count; i++) // 6 places d'inventaires
        {
            Composite pokemonNumber = new Composite("Pokemon n° " + i);
            inventory.Add(pokemonNumber);

            // Add the Composite ==> THE NAME
            Composite name = new Composite("Name");
            name.Add(new Leaf(pokemonCreators[i].pokemonCreatorLists.pokemonName));
            
            pokemonNumber.Add(name);
            
            // Add the Composite ==> Object
            Composite obj = new Composite("Object");    
            obj.Add(new Leaf(pokemonCreators[i].pokemonCreatorLists.objInHand));

            pokemonNumber.Add(obj);
            
        
            // Add the Composite ==> Attacks
            Composite attacks = new Composite("Attacks");
            for (int j = 0; j < pokemonCreators[i].pokemonCreatorLists.attack.Count; j++)
            {
                attacks.Add(new Leaf(pokemonCreators[i].pokemonCreatorLists.attack[j].attackName + " // " + pokemonCreators[i].pokemonCreatorLists.attack[j].attackDamage + " Damage"));
            }

            pokemonNumber.Add(attacks);
            
            // Recursively display tree
            inventory.Display(1);
        }
        

    }
}

abstract class Component
{
    protected string name;
    
    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
}


class Composite : Component
{
    private List<Component> _children = new List<Component>();
    
    public Composite(string name) : base(name)
    {
    }

    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);
        
        foreach (Component component in _children)
        {
            component.Display(depth + 3);
        }
    }
}


class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }

    public override void Add(Component c)
    {
        Debug.Log("Cannot add to a leaf");
    }

    public override void Remove(Component c)
    {
        Debug.Log("Cannot remove from a leaf");
    }

    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);
    }
}





[Serializable]
public class PokemonCreator
{
    public PokemonCreatorList pokemonCreatorLists;
}

[Serializable]
public class PokemonCreatorList
{
    public string pokemonName;
    public string objInHand;
    
    public List<PokemonCreatorListAttacks> attack;
}

[Serializable]
public class PokemonCreatorListAttacks
{
    public string attackName;
    public int attackDamage;
}
