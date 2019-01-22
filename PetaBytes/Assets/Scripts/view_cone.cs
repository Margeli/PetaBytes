using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_cone : MonoBehaviour {


    public float view_distance = 10;
    public float fov = 40;

    public float d;

    public LayerMask player_mask;
    public ContactFilter2D player_filter_from_player_mask;
    public ContactFilter2D walls_filter;

    Vector2[] points;

    PolygonCollider2D view_cone_polygon;

    AnimalBehaviour animal_behaviour;
    
	// Use this for initialization
	void Start () {
        view_cone_polygon = gameObject.GetComponent<PolygonCollider2D>();
        animal_behaviour = gameObject.GetComponentInParent<AnimalBehaviour>();
        points = new Vector2[6];

        player_filter_from_player_mask.layerMask = player_mask;
	}
	
	// Update is called once per frame
	void Update () {
        SetTrianlge(view_distance, fov);
        CheckIfPlayerInSight();
        CheckForWalls();
    }

    void SetTrianlge(float radius, float angle)
    {
        d = radius / Mathf.Cos((angle/2) * Mathf.Deg2Rad);

        points[0].x = 0;
        points[0].y = 0;

        points[1].x = radius * Mathf.Cos((angle / 2) * Mathf.Deg2Rad);
        points[1].y = radius * Mathf.Sin((angle / 2) * Mathf.Deg2Rad); 

        points[2].x = radius * Mathf.Cos((angle / 4) * Mathf.Deg2Rad);
        points[2].y = radius * Mathf.Sin((angle / 4) * Mathf.Deg2Rad);

        points[3].x = radius; //center
        points[3].y = 0;

        points[4].x = radius * Mathf.Cos((angle / 4) * Mathf.Deg2Rad);
        points[4].y = -radius * Mathf.Sin((angle / 4) * Mathf.Deg2Rad);

        points[5].x = radius * Mathf.Cos((angle / 2) * Mathf.Deg2Rad);
        points[5].y = -radius * Mathf.Sin((angle / 2) * Mathf.Deg2Rad);  //positive

        view_cone_polygon.SetPath(0,points);

    }

    void CheckForWalls()
    {
        Collider2D[] colliders_inside = new Collider2D[10];
        int cols_found = view_cone_polygon.OverlapCollider(walls_filter, colliders_inside);

        if (cols_found > 0)
        {
            PolygonCollider2D view_cone_polygon = colliders_inside[0].GetComponent<PolygonCollider2D>();
            print("ehat");
        }
    }

    void CheckIfPlayerInSight()
    {
        
        Collider2D[] colliders_inside = new Collider2D[10];
        int cols_found = view_cone_polygon.OverlapCollider(player_filter_from_player_mask, colliders_inside);

        if (cols_found > 0)
        {
            bool player_seen = false;
            foreach (Collider2D col in colliders_inside)
            {
                if (col)
                    if (col.gameObject.tag == "Player")
                        player_seen = true;
            }
            if (player_seen)
                animal_behaviour.player_in_sight = true;
            else
                animal_behaviour.player_in_sight = false;
        }

    }
}
