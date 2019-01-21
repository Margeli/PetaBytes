using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 9f;
    public float max_mov_velocity = 5.0f;
    public float max_mov_acceleration = 0.1f;
    public float max_rot_velocity = 10.0f; // in degrees / second
    public float max_rot_acceleration = 0.1f;


    [Header("-------- Read Only --------")]
    public Vector3 movement = Vector3.zero;
    public float rotation = 0.0f; // degrees

    private Vector3 movement_velocity;
    private float angular_velocity;

    // Use this for initialization
    void Start () {
        movement_velocity = Vector3.zero;
        angular_velocity = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            movement_velocity.y = speed;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            movement.y = 0f;
            movement_velocity.y = 0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement_velocity.y = -speed;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movement.y = 0f;
            movement_velocity.y = 0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement_velocity.x = speed;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movement.x = 0f;
            movement_velocity.x = 0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement_velocity.x = -speed;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movement.x = 0f;
            movement_velocity.x = 0f;
        }

        // cap velocity
        if (movement.magnitude > max_mov_velocity)
        {
            movement.Normalize();
            movement *= max_mov_velocity;
        }
        
        movement += movement_velocity;
        rotation += angular_velocity;

        Mathf.Clamp(rotation, -max_rot_velocity, max_rot_velocity);

        // final rotate
        transform.rotation *= Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.up);

        // finally move
        transform.position += movement * Time.deltaTime;
    }

    void MoveWithKey(int num)
    {
        if (num == 1)
            movement_velocity += Vector3.up;
        else if (num == 2 && Mathf.Approximately(movement_velocity.y, 0.0f) == false)
        {
            movement_velocity  -=  Vector3.up;
        }
    }

}

