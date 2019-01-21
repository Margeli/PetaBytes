using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour {

    public bool scared = false;
    public bool player_in_sight = false;

    public GameObject panel;


    public AudioSource audioSource;
    public AudioClip[] audioClips;

    bool fxPlayed = false;
    public float time;
	// Use this for initialization
	void Start () {
        audioSource.Pause();
	}
	
	// Update is called once per frame
	void Update () {
        if (scared)
        {
            time += Time.deltaTime;
            if (!fxPlayed)
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
            if (time > 3f) //Must put set active to false when the animation done
            {
                gameObject.SetActive(false);
                audioSource.Pause();
            }
        }
        if (player_in_sight)
        {
            panel.SetActive(true);
            Debug.Log("Player seen!");
        }
	}
}
