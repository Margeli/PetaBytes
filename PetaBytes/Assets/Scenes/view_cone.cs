using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_cone : MonoBehaviour {


    public float view_distance = 10;
    public float fov = 40;

    public float d;

    Vector2[] points;

    PolygonCollider2D view_cone_polygon;
    
	// Use this for initialization
	void Start () {
        view_cone_polygon = gameObject.GetComponent<PolygonCollider2D>();
        points = new Vector2[3];


	}
	
	// Update is called once per frame
	void Update () {
        SetTrianlge(view_distance, fov);
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
}
