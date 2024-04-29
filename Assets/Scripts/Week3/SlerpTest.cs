using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpTest : MonoBehaviour
{
    public Transform startPoint, endPoint, center;
    public int count;
    public float radius;

    private void OnDrawGizmos()
    {
        foreach (var point in EvaluateSlerpPoints(startPoint.position, endPoint.position, center.position, count))
        {
            Gizmos.DrawSphere(point, radius);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(center.position, radius * 2);
    }

    IEnumerable<Vector3> EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center, int count)
    {
        var startRelativeCenter = start - center;
        var endRelativeCenter = end - center;

        var f = 1f / count;
        for (float i = 0; i < 1+f; i++)
        {
            yield return Vector3.Slerp(startRelativeCenter, endRelativeCenter, i) + center;
        }
    }
}
