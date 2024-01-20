using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorPattern : MonoBehaviour
{
    void Start()
    {
        // Create Pokemon
        PokemonDecorator pokemonDecorator = new PokemonDecorator("Picachu", "Coup de lame", 10);
        pokemonDecorator.Display();

        // Make video borrowable, then borrow and display
        Debug.Log("\n NOW LET ME PRESENT TO YOU THE NEW ..... POKEMONNN:");

        ShinnyPokemonDecorator shinnyPokemonDecorator = new ShinnyPokemonDecorator(pokemonDecorator);
        shinnyPokemonDecorator.ChangePokemonName("Picachu but Soooo good");
        shinnyPokemonDecorator.ChangePokemonAttackName("You deffinatly going to be dead");

        shinnyPokemonDecorator.Display();
        
        Debug.Log("\n ----END DECORATOR----\n");
    }
}

/// <summary>
/// The 'Component' abstract class
/// </summary>
abstract class LibraryItem
{
    private int _nbrOfPokemon;

    // Property
    public int NbrOfPokemon
    {
        get { return _nbrOfPokemon; }
        set { _nbrOfPokemon = value; }
    }

    public abstract void Display();
    public abstract void ChangePokemonName(string name);
    public abstract void ChangePokemonAttackName(string attack);
}

/// <summary>
/// The 'ConcreteComponent' class
/// </summary>
class PokemonDecorator : LibraryItem
{
    private string _name;
    private string _attack;

    // Constructor
    public PokemonDecorator(string name, string attack, int nbrOfPokemon)
    {
        this._name = name;
        this._attack = attack;
        this.NbrOfPokemon = nbrOfPokemon;
    }

    public override void Display()
    {
        Debug.Log("\nPokemonDecorator ------ ");
        Debug.Log(" name: "+ _name);
        Debug.Log(" attack: "+ _attack);
        Debug.Log(" # N~: "+ NbrOfPokemon);
    }

    public override void ChangePokemonName(string name)
    {
        this._name = name;
    }

    public override void ChangePokemonAttackName(string attack)
    {
        this._attack = attack;
    }
}

/// <summary>
/// The 'Decorator' abstract class
/// </summary>
abstract class Decorator : LibraryItem
{
    protected LibraryItem libraryItem;

    // Constructor
    public Decorator(LibraryItem libraryItem)
    {
        this.libraryItem = libraryItem;
    }

    public override void Display()
    {
        libraryItem.Display();
    }
}


/// <summary>
/// The 'ConcreteDecorator' class
/// </summary>
class ShinnyPokemonDecorator : Decorator
{
    protected List<string> borrowers = new List<string>();

    // Constructor
    public ShinnyPokemonDecorator(LibraryItem libraryItem) : base(libraryItem)
    {
    }
    public override void ChangePokemonName(string name)
    {
        borrowers.Add(name);
        libraryItem.NbrOfPokemon--;
        libraryItem.ChangePokemonName(name);
    }

    public override void ChangePokemonAttackName(string attack)
    {
        libraryItem.ChangePokemonName(attack);
    }

    public void ReturnItem(string name)
    {
        borrowers.Remove(name);
        libraryItem.NbrOfPokemon++;
    }

    public override void Display()
    {
        base.Display();

        foreach (string borrower in borrowers)
        {
            Debug.Log(" borrower: " + borrower);
        }
    }
}
