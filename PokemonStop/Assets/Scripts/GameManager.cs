using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imports system for C#'s version of Random, instead of Unity's
using System;
//Imports SceneManagement to launch other scenes
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;
    public ArrayList pokemanz;
    public int pokeballs = 10;

    public System.Random rnd;

    //Awake is always called before any Start functions
    void Awake(){
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        DontDestroyOnLoad(instance);

        rnd = new System.Random();
    }

    // Use this for initialization
    void Start () {
        //Create a new arraylist and store it in pokemanz
        pokemanz = new ArrayList();
        UpdateHUD();
    }

    public bool ThrowPokeball() {
        if (pokeballs > 0) {
            pokeballs--;
            UpdateHUD();
            return true;
        }
        return false;
    }

    //Add a new pokemon to the list
    public void AddPokemon(string poke){
        pokemanz.Add(poke);
        UpdateHUD();
    }

    public void GoToCapture() {
        SceneManager.LoadScene("Capture");
    }

    public void GoToExplore() {
        SceneManager.LoadScene("Explore");
    }

    void UpdateHUD() {
        GameObject.Find("PokeballTotal").GetComponent<Text>().text = "Total Pokeballs: " + pokeballs;

        string allPokemen = "My Pokemon:\n";
        foreach (string poke in pokemanz) {
            allPokemen += poke + "\n";
        }
        GameObject.Find("PokemonList").GetComponent<Text>().text = allPokemen;
    }
}
