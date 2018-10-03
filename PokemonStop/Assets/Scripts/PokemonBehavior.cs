using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to pokemon in capture scene
public class PokemonBehavior : MonoBehaviour {
    //Array of possible pokemon sprites
    public Sprite[] sprites;
    //Names of possible pokemon, corresponding to sprites
    public string[] spriteNames;
    //Name of this pokemon
    public string spriteName;

	// When the scene loads, this is run; before Start method
	void Awake () {
        //Generates a random number corresponding to a pokemon
        int randomNum = GameManager.instance.rnd.Next(0, sprites.Length);
        //Renders this sprite, based on array of possible sprites and 
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[randomNum];
        //Sets name of this pokemon, corresponding to the random number and sprite chosen
        spriteName = spriteNames[randomNum];
	}
}
