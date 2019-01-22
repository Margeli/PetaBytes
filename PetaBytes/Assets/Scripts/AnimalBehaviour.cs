using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour {

    public bool scared = false;
    public bool player_in_sight = false;
    public bool dead = false;
    public float deadTime = 1.5f;
    public GameObject exclamation;
    float deadTimer = 0;

    public enum Type {
        NONE,
        CHICKEN,
        PIG
    }

    public Type type;
    // public GameObject panel;

    public AnimalsClips animalsClips;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    bool fxPlayed = false;
    public float time;

   
    Animator anim;
    Animation death;
    Move move;
    FollowCurve followCurve;
    SteeringFollowPath followPath;

    // Use this for initialization
    void Start()
    {
        //audioSource.Pause();
        audioClips = animalsClips.GetAudioClips(type);
        anim = GetComponent<Animator>();
        move = GetComponent<Move>();
        followCurve = GetComponent<FollowCurve>();
        followPath = GetComponent<SteeringFollowPath>();
    }
	
	// Update is called once per frame
	void Update () {
        if (scared)
        {
            if (move != null)
                move.SetStop(true);
            if (followPath != null)
                followPath.SetStop(true);
            if (followCurve != null)
            {
                followCurve.SetStop(true);
            }

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
                GameObject.Find("PointsGO").GetComponent<Punctuation>().preys--;
                GameObject.Find("PointsGO").GetComponent<Punctuation>().UpdatePoints(100);
                GetComponentInChildren<view_cone>().enabled = false;
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
            exclamation.SetActive(true);
            
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
