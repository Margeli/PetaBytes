using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour {

    public bool scared = false;
    public bool player_in_sight = false;
    public bool dead = false;
    public float deadTime = 2;
    float deadTimer = 0;

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
    Animator anim;
    Animation death;

	// Use this for initialization
	void Start () {
      audioSource.Pause();
      audioClips = animalsClips.GetAudioClips(type);
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (scared)
        {
            time += Time.deltaTime;
            if (!fxPlayed)
            {
                if (type == Type.CHICKEN)
                {
                    anim.Play("ChickenDie");
                }
                if(type == Type.PIG)
                {
                    anim.Play("PigDie");
                }
                audioSource.PlayOneShot(audioClips[0]);
                fxPlayed = true;
            }
            if (!audioSource.isPlaying) //Must put set active to false when the animation done
            {
                dead = true;               
                audioSource.Pause();
            }
        }
        if (player_in_sight)
        {
           // panel.SetActive(true);
            Debug.Log("Player seen!");
            GameObject.Find("PointsGO").GetComponent<Punctuation>().detected = true;
            
        }
        if (dead)
        {
            if (deadTimer > deadTime)
            {

                gameObject.SetActive(false);
            }
            else
            {
                deadTimer += Time.deltaTime;
            }
        }
	}
}
