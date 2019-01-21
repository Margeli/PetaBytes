using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : SteeringAbstract
{

    Move move;
    SteeringSeek seek;
    public BGCcMath path;
    float tot_distance;
    float point_distance;
    float current_pos;

    Vector3 closest_point;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();

        //Calculate the closest point in the range [0,1] from this gameobject to the path
        closest_point = path.CalcPositionByClosestPoint(transform.position, out point_distance);
        tot_distance = path.GetDistance();
        current_pos = point_distance / tot_distance;
    }

    // Update is called once per frame
    void Update()
    {

        //Check if the tank is close enough to the desired point
        seek.Steer(closest_point);

        // If so, create a new point further ahead in the path
        if ((transform.position - closest_point).magnitude <= 0.1)
        {
            current_pos += 0.01f;
            if (current_pos >= 1)
                current_pos = 0;
            closest_point = path.CalcPositionByDistanceRatio(current_pos);
        }

    }

    void OnDrawGizmosSelected()
    {

        if (isActiveAndEnabled)
        {
            // Display the explosion radius when selected
            Gizmos.color = Color.green;
            // Useful if you draw a sphere on the closest point to the path
        }

    }
}