using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainedQuadraticBezierCurves : MonoBehaviour
{
    public float t; // t varies from 0 to 1
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public int numPoints = 50; //Number of points in the line
    private LineRenderer lineRendererL0;
    private LineRenderer lineRendererL1;
    private LineRenderer lineRendererL2;
    private LineRenderer lineRendererL3;
    private LineRenderer lineRendererQ0;
    private LineRenderer lineRendererQ1;

    // Start is called before the first frame update
    void Start()
    {
        lineRendererL0 = CreateLineRenderer(Color.blue, Color.blue, 0.1f, 0.1f);
        lineRendererL1 = CreateLineRenderer(Color.yellow, Color.yellow, 0.1f, 0.1f);
        lineRendererL2 = CreateLineRenderer(Color.blue, Color.blue, 0.1f, 0.1f);
        lineRendererL3 = CreateLineRenderer(Color.yellow, Color.yellow, 0.1f, 0.1f);
        lineRendererQ0 = CreateLineRenderer(Color.green, Color.red, 0.1f, 0.5f);
        lineRendererQ1 = CreateLineRenderer(Color.green, Color.red, 0.1f, 0.5f);

        lineRendererQ0.positionCount = numPoints;
        lineRendererQ1.positionCount = numPoints;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure t is clamped between 0 and 1
        t = Mathf.Clamp01(t);

        // Draw the Linear Bezier segments and the Quadratic Bezier Curve
        DrawLinearBezier(lineRendererL0, p0.position, p1.position);
        DrawLinearBezier(lineRendererL1, p1.position, p2.position);
        DrawLinearBezier(lineRendererL2, p2.position, p3.position);
        DrawLinearBezier(lineRendererL3, p3.position, p0.position);
        DrawQuadraticBezier(lineRendererQ0, p0.position, p1.position, p2.position);
        DrawQuadraticBezier(lineRendererQ1, p2.position, p3.position, p0.position);

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

    void DrawQuadraticBezier(LineRenderer lr, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        for (int i = 0; i < numPoints; i++)
        {
            // Normalize t value between 0 and 1
            float tValue = i / (numPoints - 1f);

            // Calculate the <L0(t)> First Linear Bezier Point
            Vector3 l0 = (1 - tValue) * p0 + tValue * p1;

            // Calculate the <L1(t)> Second Linear Bezier Point
            Vector3 l1 = (1 - tValue) * p1 + tValue * p2;

            // Calculate the <Q0(t)> Quadratic Bezier Point
            Vector3 q0 = (1 - tValue) * l0 + tValue * l1;

            lr.SetPosition(i, q0);

        }
    }
}
