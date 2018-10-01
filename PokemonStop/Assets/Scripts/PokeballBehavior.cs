using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballBehavior : MonoBehaviour {
    public float moveSpeed = 6.0f;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "OtherPokeman") {
            CaptureDirector.instance.CapturePokemon();
            collision.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
        }    
    }
}
