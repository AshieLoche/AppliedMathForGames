using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LinearBezierCurve : MonoBehaviour
{

    public float t; // t varies from 0 to 1
    public Transform p0;
    public Transform p1;
    public int numPoints = 50; //Number of points in the line
    private LineRenderer lineRendererL0;

    // Start is called before the first frame update
    void Start()
    {
        lineRendererL0 = GetComponent<LineRenderer>();
        lineRendererL0.material = new Material(Shader.Find("Sprites/Default"));
        lineRendererL0.widthMultiplier = 0.1f;
        lineRendererL0.positionCount = numPoints;
        lineRendererL0.startColor = Color.green;
        lineRendererL0.endColor = Color.red;
        lineRendererL0.startWidth = 0.1f;
        lineRendererL0.endWidth = 0.5f;
        lineRendererL0.useWorldSpace = true;
        lineRendererL0.numCapVertices = 10;
    }

    // Update is called once per frame
    void Update()
    {

        // Ensure t is clamped between 0 and 1
        t = Mathf.Clamp01(t);

        for (int i = 0; i < numPoints; i++)
        {
            // Normalize t value between 0 and 1
            float tValue = i / (numPoints - 1f); 
            // Calculate the <L0(t)> Linear Bezier Point.
            Vector3 l0 = (1 - tValue) * p0.position + tValue * p1.position;
            lineRendererL0.SetPosition(i, l0);
        }
        
    }
}
