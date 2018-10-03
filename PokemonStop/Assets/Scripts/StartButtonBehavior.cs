using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Imports SceneManagement so we can load another scene
using UnityEngine.SceneManagement;
//Import UI so we can use the Button element
using UnityEngine.UI;

public class StartButtonBehavior : MonoBehaviour {

    //Sets listener for the button to call the OnClick method
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    //If the button is clicked, load the explore scene
    void OnClick() {
        SceneManager.LoadScene("Explore");
    }
}
