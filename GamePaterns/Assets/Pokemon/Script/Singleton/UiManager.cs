using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI textGame;
    [SerializeField] private float baseTimer = 3;
    private float timer;
    private bool activateTimer;
    
    public static UiManager instance;

    [Header("ObserverPattern")] 
    public int goldMoney;
    public int PokeBallNbr;
    public List<string> nameOfThePokemon;
    
    public TextMeshProUGUI textgoldMoney;
    public TextMeshProUGUI textPokeBallNbr;
    public List<TextMeshProUGUI> textnameOfThePokemons;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InventoryManager.instance.OnCombatWithEntities = SetObserverPattern;
    }

    /// <summary>
    /// Get The information from the InventoryManager Actions 
    /// </summary>
    /// <param name="textgoldMoney"></param>
    /// <param name="textPokeBallNbr"></param>
    /// <param name="textnameOfThePokemons"></param>
    private void SetObserverPattern(int textgoldMoney, int textPokeBallNbr, string textnameOfThePokemons)
    {
        this.textgoldMoney.text = null;
        this.textgoldMoney.text = textgoldMoney.ToString() + " Gold Amount";

        this.textPokeBallNbr.text = null;
        this.textPokeBallNbr.text = textPokeBallNbr.ToString()+ " Pokeball Amount";
        
        if(textnameOfThePokemons == String.Empty) return;
        nameOfThePokemon.Add(textnameOfThePokemons);
        for (var index = 0; index < nameOfThePokemon.Count; index++)
        {
            this.textnameOfThePokemons[index].text = nameOfThePokemon[index];
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!activateTimer) return;
        timer -= Time.deltaTime * 1;
        if (!(timer < 0)) return;
        activateTimer = false;
        textGame.text = "";
    }

    public void ChangeTextGame()
    {
        activateTimer = true;
        timer = baseTimer;
    }
}
