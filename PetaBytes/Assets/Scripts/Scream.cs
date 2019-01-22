using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scream : MonoBehaviour {


    public GameObject scream;
    public GameObject dmgArea;
    public float spread = 0.5f;
    public float maxRadius =40;
    public float thin = 0.1f;
    public float initialRadius = 1.0f;
    public float dmgDuration = 0.25f;
    public LayerMask mask;
    public float maxLoud = 100.0f;


    [Header("-------- Read Only --------")]
    public float scale;    
    public float currentDmgDuration;
    int j = 1;


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
            scream.SetActive(false);
            dmgArea.transform.localScale = new Vector3(scale, thin, scale);
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(pos , 0.66f * scale, mask);// 0.5 is the radius of the collider   
            for (int i = 0; i < colliders.Length; i++)
            {
                AnimalBehaviour animal = colliders[i].gameObject.GetComponent<AnimalBehaviour>();
               
                if(animal)
                    animal.scared = true;
                Vector3 dist =animal.transform.position - transform.position;
                float n = dist.magnitude;
                 
            }
            scale = initialRadius;
        }

        if (dmgArea.activeInHierarchy)
        {
            if (currentDmgDuration < dmgDuration){
                currentDmgDuration += Time.deltaTime;
                if (currentDmgDuration< dmgDuration* j / 4)
                {
                    dmgArea.transform.Rotate(new Vector3(0, 50, 0));
                    dmgArea.transform.localScale = new Vector3(dmgArea.transform.localScale.x - 0.05f*((-1)^j), thin, dmgArea.transform.localScale.z -  0.05f*((-1) ^ j));
                    j++;
                }
                
            }
            else
            {
                dmgArea.SetActive(false);
                scream.SetActive(true);
                currentDmgDuration = 0;
                j = 1;
            }           
        }

        scale = Mathf.Clamp(scale, 0, maxRadius);
        scream.transform.localScale = new Vector3(scale, thin, scale);
        scream.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+0.5f);
        dmgArea.transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z+ 0.5f);
    }
}
