using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class TallGrass : MonoBehaviour 
{
    public enum Road
    {
        Road1,
        Road2,
        Road3
    }
    public Road road;


    public void Interact(Road road)
    {
        switch (road)
        {
            case Road.Road1:
                Road1();
                break;
            case Road.Road2:
                Road2();
                break;
            case Road.Road3:
                Road3();
                break;
        }
    }

    private void Start() //Spawn elements in the tall grass
    {
        GameObject tallGrassEntitie = Instantiate(GameManager.instance.Pokemon,
            new Vector3((int)transform.position.x, 0, (int)transform.position.z)
            , Quaternion.identity);
        
        tallGrassEntitie.GetComponent<TallGrassEntitie>().fromWichTallGrassIAm = this;
    }

    private void Road1()
    {
        //TODO : Create Factory "Zone 1 " 
        ContinentFactory zone1 = new Zone1();
        PokemonWorld world = new PokemonWorld(zone1);
        world.CatchAPokemon();
    }
    
    private void Road2()
    {
        //TODO : Create Factory "Zone 2 " 
        ContinentFactory zone2 = new Zone2();
        PokemonWorld world = new PokemonWorld(zone2);
        world.Combat();
    }
    
    private void Road3()
    {
        //TODO : Create Factory "Zone 3 " 
    }

    private void OnDrawGizmos()
    {
        Handles.Label(transform.position + Vector3.up, transform.name);
    }
}


abstract class ContinentFactory // Abstract Factory 
{
    public abstract Wild CreatePokemon();
    public abstract Trainer CreateTrainer();
}


class Zone1 : ContinentFactory // Concrete Factory A
{
    public override Wild CreatePokemon()
    {
        return new Pikachu();
    }
    public override Trainer CreateTrainer()
    {
        return new Etienne();
    }
}

class Zone2 : ContinentFactory // Concrete Factory B
{
    public override Wild CreatePokemon()
    {
        return new Bulbasaur();
    }
    public override Trainer CreateTrainer()
    {
        return new Cedric();
    }
}

abstract class Wild // Abstract Product A
{
    public abstract void CatchAPokemon(Wild pokemon); // Can catch Pokemon
    public abstract void DidNotSuccededToCatch(Wild pokemon);
}

abstract class Trainer // Abstract Product B
{
    public abstract void WinCombat(Trainer h); // can fight with his Pokemon
    public abstract void LostCombat(Trainer h);
}

class Pikachu : Wild // Product A zone 1  
{
    public override void CatchAPokemon(Wild pokemon)
    {
        Debug.Log(PlayerController.instance.transform.name + " Catch " + pokemon.GetType().Name + " !");
        UiManager.instance.ChangeTextGame();
        UiManager.instance.textGame.text = PlayerController.instance.transform.name + " Catch " + pokemon.GetType().Name + " !";
    }

    public override void DidNotSuccededToCatch(Wild pokemon)
    {
        Debug.Log(PlayerController.instance.transform.name + " Did Catch Not Catch " + pokemon.GetType().Name + " !");
        UiManager.instance.ChangeTextGame();
        UiManager.instance.textGame.text = PlayerController.instance.transform.name + " Did Catch Not Catch " + pokemon.GetType().Name + " !";
    }
}

class Etienne : Trainer // Product B zone 1 
{
    public override void WinCombat(Trainer pokemon)
    {
        Debug.Log(PlayerController.instance.transform.name + " Win the Fight with " + pokemon.GetType().Name + " !");
        UiManager.instance.ChangeTextGame();
        UiManager.instance.textGame.text = PlayerController.instance.transform.name + " Win the Fight with " + pokemon.GetType().Name + " !";
    }

    public override void LostCombat(Trainer h)
    {
        Debug.Log(PlayerController.instance.transform.name + " Lost the Fight with " + h.GetType().Name + " !");
        UiManager.instance.ChangeTextGame();
        UiManager.instance.textGame.text = PlayerController.instance.transform.name + " Lost the Fight with " + h.GetType().Name + " !";
    }
}

class Bulbasaur : Wild // Product A zone 2  
{
    public override void CatchAPokemon(Wild pokemon)
    {
        Debug.Log(PlayerController.instance.transform.name + " Did Catch Not Catch " + pokemon.GetType().Name + " !");
        UiManager.instance.ChangeTextGame();
        UiManager.instance.textGame.text = PlayerController.instance.transform.name + " Catch " + pokemon.GetType().Name + " !";
    }

    public override void DidNotSuccededToCatch(Wild pokemon)
    {
        Debug.Log(PlayerController.instance.transform.name + " Did Catch Not Catch " + pokemon.GetType().Name + " !");
        UiManager.instance.ChangeTextGame();
        UiManager.instance.textGame.text = PlayerController.instance.transform.name + " Did Catch Not Catch " + pokemon.GetType().Name + " !";
    }
}

class Cedric : Trainer // Product B zone 2
{
    public override void WinCombat(Trainer pokemon)
    {
        Debug.Log(PlayerController.instance.transform.name + " Win the Fight with " + pokemon.GetType().Name + " !");
        UiManager.instance.ChangeTextGame();
        UiManager.instance.textGame.text = PlayerController.instance.transform.name + " Win the Fight with " + pokemon.GetType().Name + " !";
    }
    public override void LostCombat(Trainer h)
    {
        Debug.Log(PlayerController.instance.transform.name + " Lost the Fight with " + h.GetType().Name + " !");
        UiManager.instance.ChangeTextGame();
        UiManager.instance.textGame.text = PlayerController.instance.transform.name + " Lost the Fight with " + h.GetType().Name + " !";
    }
}



class PokemonWorld
{
    private Wild pokemon;
    private Trainer trainer;

    // Constructor
    public PokemonWorld(ContinentFactory factory)
    {
        pokemon = factory.CreatePokemon();
        trainer = factory.CreateTrainer();
    }

    public void CatchAPokemon()
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber > 50)
        {
            pokemon.CatchAPokemon(pokemon);
        }
        else
        {
            pokemon.DidNotSuccededToCatch(pokemon);
        }
    }

    public void Combat()
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber > 50)
        {
            trainer.WinCombat(trainer);
        }
        else
        {
            trainer.LostCombat(trainer);
        }
    }
}


