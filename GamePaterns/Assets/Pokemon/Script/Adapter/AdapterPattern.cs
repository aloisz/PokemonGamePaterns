using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdapterPattern : MonoBehaviour
{
    void Start()
    {
        Debug.Log("---------------BEGIN ADAPTER------------");
        Debug.Log("Pokemon from 1st Gen");
        Debug.Log("\n");
        Pokemon1stGen picachu = new Pokemon1stGen("picachu", 25,25,25,25,25);
        picachu.Display();
        
        Debug.Log("\n");
        Debug.Log("Pokemon from 2nd Gen");
        Debug.Log("\n");

        // Adapted chemical compounds
        Pokemon1stGen picachu2 = new Pokemon2ndGen("picachu", 25,25,25,25,25);
        picachu2.Display();
        Debug.Log("\n");
        Debug.Log("---------------END ADAPTER------------");
    }
}

/// <summary>
/// The 'Target' class
/// </summary>
class Pokemon1stGen
{
    protected string _name;
    protected float _hp;
    protected float _atk;
    protected float _def;
    protected float _spd;
    protected float _spe;

    // Constructor
    public Pokemon1stGen(string name, float hp, float atk, float def, float spd, float spe)
    {
        this._name = name;
        this._hp = hp;
        this._atk = atk;
        this._def = def;
        this._spd = spd;
        this._spe = spe;
    }

    public virtual void Display()
    {
        Debug.Log("\nCompound:  " + _name + "------");
        Debug.Log(" hp: " + _hp);
        Debug.Log(" atk: " + _atk);
        Debug.Log(" def : " + _def);
        Debug.Log(" spd Pt: " + _spd);
        Debug.Log(" spe Pt: " + _spe);
    }
}


/// <summary>
/// The 'Adapter' class
/// </summary>
class Pokemon2ndGen : Pokemon1stGen
{
    private Adapter _adapte;
    protected float _atkSpe;
    protected float _defSpe;

    // Constructor
    public Pokemon2ndGen(string name, float hp, float atk, float def, float spd, float spe) 
        : base(name, hp, atk, def, spd, spe)
    {
    }

    public override void Display()
    {
        // The Adaptee
        _adapte = new Adapter();
        
        _atkSpe = _adapte.GetDefSpe(_name, _def, _spd);
        _defSpe = _adapte.GetAtkSpe(_name, _atk, _spe);

        //base.Display();
        Debug.Log(" atkSpe: " + _atkSpe);
        Debug.Log(" defSpe: " + _defSpe);
    }
}

/// <summary>
/// The 'Adaptee' class
/// </summary>
class Adapter
{
    // ALL the operation may not be accurate because I dont know the real stats
    
    public float GetAtkSpe(string compound, float atk, float spe)
    {
        switch (compound.ToLower())
        {
            case "picachu": return atk + spe;
            case "bulbizar": return atk + spe * 21;
            case "salameche": return atk + spe -25;
            default: return atk + spe;
        }
    }

    public float GetDefSpe(string compound, float def, float spd)
    {
        switch (compound.ToLower())
        {
            case "picachu": return def * spd;
            case "bulbizar": return def * spd -95;
            case "salameche": return def * spd;
            default: return def * spd;
        }
    }
}
