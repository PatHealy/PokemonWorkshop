using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballBehavior : MonoBehaviour {
    //speed of the pokeball's travel to the right
    public float moveSpeed = 6.0f;
	
	// Update is called once per frame
	void FixedUpdate () {
        //Always move this pokeball to the right, over time
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }

    //If this ball collides with a pokemon, destroy this object, make the pokemon's sprite invisible, and call method to capture the pokemon
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "OtherPokeman") {
            CaptureDirector.instance.CapturePokemon();
            collision.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
        }    
    }
}
