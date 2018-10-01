using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureDirector : MonoBehaviour {
    int stateIndex;
    string[] states;
    public Text description;
    public PokemonBehavior pokeman;

	// Use this for initialization
	void Start () {
        stateIndex = -1;
        states = new string[]{"A wild " + pokeman.spriteName + " appeared.", 
            "You throw your pokeball.",
            pokeman.spriteName + " was caught."
        };
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown){
            if(stateIndex < states.Length - 1)
                stateIndex++;

            if (!states[stateIndex].Equals("end"))
                description.text = states[stateIndex];
            else
                EndScene();
        }
	}

    void EndScene(){

    }


}
