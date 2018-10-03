using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imports UI so we can access UI elements, like Text
using UnityEngine.UI;

public class CaptureDirector : MonoBehaviour {
    //index representing current state of the state machine
    int stateIndex;
    //Array of states of the state machine
    string[] states;
    //Text object at the bottom of the screen
    public Text description;
    //Pokemon in the scene
    public PokemonBehavior pokeman;
    //Static instance of this class; other classes can reference this
    public static CaptureDirector instance;

    public GameObject pokeballPrefab;

    //At awake, set static instance to this object
    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        //Starts the machine at initial state of node 0
        stateIndex = 0;
        //Defines the nodes of the state machine
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
        //On any key down, try to change states
        if(Input.anyKeyDown){
            //if we haven't reached the end of the states, continue
            if (stateIndex < states.Length)
            {
                //If state is 'throw_pokeball', call that method
                //If state is 'end', call that method
                //Otherwise, set text block = this state and increment state
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
        //Calls game manager method to throw a pokeball
        bool success = GameManager.instance.ThrowPokeball();
        //if throw was successful (you had pokeballs left), instantiate a pokeball
        //Otherwise, change state to end of machine where you are out of pokeballs
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

    //Called when pokeball hits pokemon
    public void CapturePokemon() {
        //increment state
        stateIndex++;
        //Add pokemon to our data structure in the game manager
        GameManager.instance.AddPokemon(pokeman.spriteName);
    }

    void EndScene(){
        //End this scene and return to the exploration scene
        GameManager.instance.GoToExplore();
    }


}
