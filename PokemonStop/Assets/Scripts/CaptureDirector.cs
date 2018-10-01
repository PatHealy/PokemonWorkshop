using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureDirector : MonoBehaviour {
    int stateIndex;
    string[] states;
    public Text description;
    public PokemonBehavior pokeman;
    public static CaptureDirector instance;

    public GameObject pokeballPrefab;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        stateIndex = 0;
        states = new string[]{"A wild " + pokeman.spriteName + " appeared.",
            "You try to throw a pokeball.",
            "throw_pokeball",
            "wait",
            pokeman.spriteName + " was caught.",
            "end",
            "wait",
            "You are out of pokeballs",
            "end"
        };
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown){
            if (stateIndex < states.Length)
            {
                if (states[stateIndex].Equals("throw_pokeball"))
                {
                    ThrowPokeball();
                }
                else if (states[stateIndex].Equals("end"))
                {
                    EndScene();
                    stateIndex++;
                }
                else if (!states[stateIndex].Equals("wait"))
                {
                    description.text = states[stateIndex];
                    stateIndex++;
                }
            }
        }
	}

    void ThrowPokeball() {
        bool success = GameManager.instance.ThrowPokeball();
        if (success)
        {
            Instantiate(pokeballPrefab, transform.position, transform.rotation);
            stateIndex++;
        }
        else {
            stateIndex = 7;
            description.text = states[stateIndex];
        }
    }

    public void CapturePokemon() {
        stateIndex++;
        GameManager.instance.AddPokemon(pokeman.spriteName);
    }

    void EndScene(){
        GameManager.instance.GoToExplore();
    }


}
