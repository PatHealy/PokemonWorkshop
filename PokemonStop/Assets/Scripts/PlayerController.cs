/* PlayerController controls the player
 * Pat Healy
 * 9/28/18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Speed of the player; public so it can be modified in inspector
    public float speed = 1;

    //Array of sprites for animated player; public so sprites can be set in inspector
    public Sprite[] sprites;

    //Renderer; set in Start
    SpriteRenderer rend;

	// Use this for initialization
	void Start () {
        //Get the renderer game component and store reference to it in rend
        rend = gameObject.GetComponent<SpriteRenderer>();

        //Start with the sprite looking right
        rend.sprite = sprites[2];
    }
	
	// FixedUpdate is called more regularly than Update
	void FixedUpdate () {
        //Default values for x and y are 0 (no movement)
        float x = 0;
        float y = 0;

        //On key press of WASD, set movement
        if(Input.GetKey(KeyCode.D)){
            x = 1;
        }
        else if(Input.GetKey(KeyCode.A)){
            x = -1;
        }

        if(Input.GetKey(KeyCode.W)){
            y = 1;
        }
        else if(Input.GetKey(KeyCode.S)){
            y = -1;
        }

        //Multiply movement by speed and delta time
        x = x * speed * Time.deltaTime;
        y = y * speed * Time.deltaTime;

        //If moving diagonally, adjust speed accordingly 
        if(Mathf.Abs(x) > 0 && Mathf.Abs(y) > 0){
            x = x / Mathf.Sqrt(2);
            y = y / Mathf.Sqrt(2);
        }

        //Vector representing the player's new position after this frame
        Vector3 newPos = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);

        //Set the player's position
        transform.SetPositionAndRotation(newPos, transform.rotation);

        //Sets sprite based on movement direction
        if (y > 0)
        {
            rend.sprite = sprites[0];
        }
        else if (y < 0)
        {
            rend.sprite = sprites[1];
        }

        //x comes later because left and right sprite overwrites up/down when moving diagonally 
        if (x > 0){
            rend.sprite = sprites[2];
        }
        else if(x < 0){
            rend.sprite = sprites[3];
        }
    }
}
