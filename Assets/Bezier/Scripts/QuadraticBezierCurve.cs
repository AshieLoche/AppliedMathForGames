using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class QuadraticBezierCurve : MonoBehaviour
{

    public float t; // t varies from 0 to 1
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public int numPoints = 50; //Number of points in the line
    private LineRenderer lineRendererL0;
    private LineRenderer lineRendererL1;
    private LineRenderer lineRendererQ0;

    // Start is called before the first frame update
    void Start()
    {
        lineRendererL0 = CreateLineRenderer(Color.blue, Color.blue, 0.1f, 0.1f);
        lineRendererL1 = CreateLineRenderer(Color.yellow, Color.yellow, 0.1f, 0.1f);
        lineRendererQ0 = CreateLineRenderer(Color.green, Color.red, 0.1f, 0.5f);

        lineRendererQ0.positionCount = numPoints;
    }

    // Update is called once per frame
    void Update()
    {

        // Ensure t is clamped between 0 and 1
        t = Mathf.Clamp01(t);

        // Draw the Linear Bezier segments and the Quadratic Bezier Curve
        DrawLinearBezier(lineRendererL0, p0.position, p1.position);
        DrawLinearBezier(lineRendererL1, p1.position, p2.position);
        DrawQuadraticBezier();

    }

    LineRenderer CreateLineRenderer(Color startColor, Color endColor, float startWidth, float endWidth)
    {
        GameObject lineObj = new GameObject("LineRenderer");
        lineObj.transform.SetParent(transform);

        LineRenderer lr = lineObj.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = startColor;
        lr.endColor = endColor;
        lr.startWidth = startWidth;
        lr.endWidth = endWidth;
        lr.useWorldSpace = true;
        lr.numCapVertices = 10;

        return lr;
    }

    void DrawLinearBezier(LineRenderer lr, Vector3 p0, Vector3 p1)
    {
        lr.positionCount = 2;
        lr.SetPosition(0, p0);
        lr.SetPosition(1, p1);
    }

    void DrawQuadraticBezier()
    {
        for (int i = 0; i < numPoints; i++)
        {
            // Normalize t value between 0 and 1
            float tValue = i / (numPoints - 1f);

            // Calculate the <L0(t)> First Linear Bezier Point
            Vector3 l0 = (1 - tValue) * p0.position + tValue * p1.position;

            // Calculate the <L1(t)> Second Linear Bezier Point
            Vector3 l1 = (1 - tValue) * p1.position + tValue * p2.position;

            // Calculate the <Q0(t)> Quadratic Bezier Point
            Vector3 q0 = (1 - tValue) * l0 + tValue * l1;

            lineRendererQ0.SetPosition(i, q0);

        }
    }

}
