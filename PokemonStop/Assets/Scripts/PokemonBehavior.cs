using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBehavior : MonoBehaviour {
    public Sprite[] sprites;
    public string[] spriteNames;
    public string spriteName;

	// Use this for initialization
	void Awake () {
        int randomNum = GameManager.instance.rnd.Next(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[randomNum];
        spriteName = spriteNames[randomNum];
	}
}
