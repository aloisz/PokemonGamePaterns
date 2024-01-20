using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorPattern : MonoBehaviour
{
    void Start()
    {
        // Create book
        PokemonDecorator pokemonDecorator = new PokemonDecorator("Picachu", "Coup de lame", 10);
        pokemonDecorator.Display();

        // Create video
        ShinnyPokemonDecorator shinnyPokemonDecorator = new ShinnyPokemonDecorator("Woh le gars ta vu", "Scchlasss", 23, 92);
        shinnyPokemonDecorator.Display();

        // Make video borrowable, then borrow and display
        Debug.Log("\n Nous fesons de super pokemon:");

        Borrowable borrowvideo = new Borrowable(shinnyPokemonDecorator);
        borrowvideo.BorrowItem("Customer #1");

        borrowvideo.Display();
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
}


/// <summary>
/// The 'ConcreteComponent' class
/// </summary>
class ShinnyPokemonDecorator : LibraryItem
{
    private string _name;
    private string _attack;
    private int _superPower;

    // Constructor
    public ShinnyPokemonDecorator(string name, string attack,
        int nbrOfPokemon, int superPower)
    {
        this._attack = attack;
        this._name = name;
        this.NbrOfPokemon = nbrOfPokemon;
        this._superPower = superPower;
    }

    public override void Display()
    {
        Debug.Log("\nShinnyPokemonDecorator ----- ");
        Debug.Log(" name: "+ _name);
        Debug.Log(" attack: "+ _attack);
        Debug.Log(" # N~: "+ NbrOfPokemon);
        Debug.Log(" SuperPower: "+ _superPower+ "\n");
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
class Borrowable : Decorator
{
    protected List<string> borrowers = new List<string>();

    // Constructor
    public Borrowable(LibraryItem libraryItem) : base(libraryItem)
    {
    }

    public void BorrowItem(string name)
    {
        borrowers.Add(name);
        libraryItem.NbrOfPokemon--;
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
