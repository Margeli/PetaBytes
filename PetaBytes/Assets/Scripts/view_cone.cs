using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_cone : MonoBehaviour {


    public float view_distance = 10;
    public float fov = 40;

    public float d;

    public LayerMask player_mask;
    public ContactFilter2D player_filter_from_player_mask;

    Vector2[] points;

    PolygonCollider2D view_cone_polygon;

    AnimalBehaviour animal_behaviour;
    
	// Use this for initialization
	void Start () {
        view_cone_polygon = gameObject.GetComponent<PolygonCollider2D>();
        animal_behaviour = gameObject.GetComponentInParent<AnimalBehaviour>();
        points = new Vector2[3];

        player_filter_from_player_mask.layerMask = player_mask;
	}
	
	// Update is called once per frame
	void Update () {
        SetTrianlge(view_distance, fov);
        CheckIfPlayerInSight();
    }

    void SetTrianlge(float radius, float angle)
    {
        d = radius / Mathf.Cos((angle/2) * Mathf.Deg2Rad);

        points[0].x = 0;
        points[0].y = 0;


        points[1].x = radius;
        points[1].y = d * Mathf.Sin((angle / 2) * Mathf.Deg2Rad);  //positive

        points[2].x = radius;
        points[2].y = -d * Mathf.Sin((angle / 2) * Mathf.Deg2Rad);

        view_cone_polygon.SetPath(0,points);

    }

    void CheckIfPlayerInSight()
    {
        
        Collider2D[] colliders_inside = new Collider2D[10];
        int cols_found = view_cone_polygon.OverlapCollider(player_filter_from_player_mask, colliders_inside);

        if (cols_found > 0)
        {
            print("hey");
        }
    }
}
