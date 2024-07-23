using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BoomerangMovement : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    public float duration = 5.0f; // Total time to complete the path
    private float elapsedTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / duration;

        if (t > 1.0f)
        {
            t = 1.0f;
            // Optionally, reset elapsed time if you want the motion to loop
            elapsedTime = 0.0f;
        }

        if (t <= 0.5f)
        {
            // First half of the movement
            float t1 = t / 0.5f; // Normalize t for the first segment
            Vector3 firstCurvePoint = CalculateQuadraticBezierPoint(t1, p0.position, p1.position, p2.position);
            transform.position = firstCurvePoint;
        }
        else
        {
            // Second half of the movement
            float t2 = (t - 0.5f) / 0.5f; // Normalize t for the second segment
            Vector3 secondCurvePoint = CalculateQuadraticBezierPoint(t2, p2.position, p3.position, p0.position);
            transform.position = secondCurvePoint;
        }
    }

    Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 point = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return point;

        //Vector3 l0 = (1 - t) * p0 + t * p1;
        //Vector3 l1 = (1 - t) * p1 + t * p2;
        //Vector3 q0 = (1 - t) * l0 + t * l1;

        //return q0;
    }
}
