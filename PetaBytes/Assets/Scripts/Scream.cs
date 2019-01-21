using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scream : MonoBehaviour {


    public GameObject scream;
    public GameObject dmgArea;
    public float spread = 0.5f;
    public float maxRadius =40;
    float thin = 0.1f;
    float initialRadius = 1.0f;
    float dmgDuration = 2.0f;

    [Header("-------- Read Only --------")]
    public float scale;
    


	// Use this for initialization
	void Start () {
        scream.transform.localScale = new Vector3(0, thin, 0);
        dmgArea.transform.localScale = new Vector3(0, thin, 0);
        dmgArea.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            scale += spread;
                       
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {            
            dmgArea.SetActive(true);
            dmgArea.transform.localScale = new Vector3(scale, thin, scale);
            scale = initialRadius;
        }

       
        scale = Mathf.Clamp(scale, 0, maxRadius);
        scream.transform.localScale = new Vector3(scale, thin, scale);
    }
}
