using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsClips : MonoBehaviour {
    public AudioClip[] chickenClips;
    public AudioClip[] pigClips;

    public AudioClip[] GetAudioClips(AnimalBehaviour.Type type)
    {
        switch (type)
        {
            case AnimalBehaviour.Type.NONE:
                return null;
            case AnimalBehaviour.Type.CHICKEN:
                return chickenClips;
            case AnimalBehaviour.Type.PIG:
                return pigClips;
        }
        return null;
    }

}
