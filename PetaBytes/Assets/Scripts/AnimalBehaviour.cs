using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour {

    public bool scared = false;
    public bool player_in_sight = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (scared)
        {
            gameObject.SetActive(false);
        }
        if (player_in_sight)
        {
            Debug.Log("Player seen!");
        }
	}
}
