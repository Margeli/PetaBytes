using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceMovement : MonoBehaviour {

    PlayerMove playerMove;

    // Use this for initialization
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        float target_degrees = Mathf.Atan2(playerMove.movement.x, playerMove.movement.y) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.AngleAxis(target_degrees, Vector3.back);
    }
}
