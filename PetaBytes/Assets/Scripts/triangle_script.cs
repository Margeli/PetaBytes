using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangle_script : MonoBehaviour {

    Vector2 vertex1;
    Vector2 vertex2;
    Vector2 vertex3;

    triangle_script()
    {
        vertex1 = new Vector2(0, 0);
        vertex2 = new Vector2(20, 20);
        vertex3 = new Vector2(20, -20);

    }

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        // make changes to the Mesh by creating arrays which contain the new values
        mesh.vertices = new Vector3[] { new Vector3(vertex1.x, vertex1.y, 0), new Vector3(vertex2.x, vertex2.y, 0), new Vector3(vertex3.x, vertex3.y, 0) };
        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        mesh.triangles = new int[] { 0, 1, 2 };
    }

    void SetPoints(Vector2[] points)
    {
        vertex1 = points[0];
        vertex2 = points[1];
        vertex3 = points[2];
        UpdateMesh();
    }

    void UpdateMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        // make changes to the Mesh by creating arrays which contain the new values
        mesh.vertices = new Vector3[] { new Vector3(vertex1.x, vertex1.y, 0), new Vector3(vertex2.x, vertex2.y, 0), new Vector3(vertex3.x, vertex3.y, 0) };
        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        mesh.triangles = new int[] { 0, 1, 2 };
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
