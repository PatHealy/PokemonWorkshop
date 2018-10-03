using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imports system for C#'s version of Random, instead of Unity's
using System;
//Imports SceneManagement to launch other scenes
using UnityEngine.SceneManagement;
//Imports UI so we can access UI elements, like Text
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;
    //An arraylist of our pokemon
    public ArrayList pokemanz;
    //Number of pokeballs we have to throw
    public int pokeballs = 10;

    //Random object; this is C#'s Random, not Unity's
    public System.Random rnd;

    //Awake is always called before any Start functions; this is where we make the GameManager a singleton
    void Awake(){
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Stays in the scene as we load other things
        DontDestroyOnLoad(instance);

        //Creates a random object to generate random numbers; C#'s random, not Unity's
        rnd = new System.Random();
    }

    // Use this for initialization
    void Start () {
        //Create a new arraylist and store it in pokemanz
        pokemanz = new ArrayList();
        //Update the HUD
        UpdateHUD();
    }

    public bool ThrowPokeball() {
        //If we have pokeballs left, throw one and update HUD, return true; otherwise return false
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
        //Update the HUD
        UpdateHUD();
    }

    //Loads the capture scene
    public void GoToCapture() {
        SceneManager.LoadScene("Capture");
    }

    //load the explore scene
    public void GoToExplore() {
        SceneManager.LoadScene("Explore");
    }

    //Updates the stats of the heads up display
    void UpdateHUD() {
        //Display our number of remaining pokeballs
        GameObject.Find("PokeballTotal").GetComponent<Text>().text = "Total Pokeballs: " + pokeballs;

        //append all of our pokemon to our HUD element
        string allPokemen = "My Pokemon:\n";
        foreach (string poke in pokemanz) {
            allPokemen += poke + "\n";
        }
        GameObject.Find("PokemonList").GetComponent<Text>().text = allPokemen;
    }
}
