using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour {

    public bool scared = false;
    public bool player_in_sight = false;

    public enum Type {
        NONE,
        CHICKEN,
        PIG
    }

    public Type type;
    // public GameObject panel;


    public AudioSource audioSource;
    public AudioClip[] audioClips;

    bool fxPlayed = false;
    public float time;

    public AnimalsClips animalsClips;

	// Use this for initialization
	void Start () {
      audioSource.Pause();
      audioClips = animalsClips.GetAudioClips(type);
	}
	
	// Update is called once per frame
	void Update () {
        if (scared)
        {
            time += Time.deltaTime;
            if (!fxPlayed)
            {
                audioSource.PlayOneShot(audioClips[0]);
                fxPlayed = true;
            }
            if (!audioSource.isPlaying) //Must put set active to false when the animation done
            {
                gameObject.SetActive(false);
                audioSource.Pause();
            }
        }
        if (player_in_sight)
        {
           // panel.SetActive(true);
            Debug.Log("Player seen!");
        }
	}
}
