
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokemonTeam : MonoBehaviour
{
	void Start ()
    {
        // Create a tree structure
        // Creation de l'inventaire des pokemon 
        Composite root = new Composite("root");
        for (int i = 1; i <= 6; i++) // 6 places d'inventaire
        {
            root.Add(new Leaf("Pokemon n° " + i));
            
            // Add the first Composite ==> THE NAME
            Composite name = new Composite("Name");
            name.Add(new Leaf("Pikachu"));
            
            root.Add(name);
            
            // Add the Composite ==> Object
            Composite obj = new Composite("Object");
            obj.Add(new Leaf("Pots"));

            name.Add(obj);
            
        
            // Add the Composite ==> Attacks
            Composite attacks = new Composite("Attacks");
            attacks.Add(new Leaf("Eclairs"));
            attacks.Add(new Leaf("Fleurs"));

            name.Add(attacks);
        
        
            // Recursively display tree
            root.Display(1);
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
