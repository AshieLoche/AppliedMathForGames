using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    public Transform aTrans;
    public Transform bTrans;
    public float distanceBetweenAToB;

    private void OnDrawGizmos()
    {
        Vector2 aVec = aTrans.position;
        Vector2 bVec = bTrans.position;

        Vector2 pt = transform.position;
        Vector2 dirToPoint = pt.normalized;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, dirToPoint);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(-5,0), new Vector2(5, 0));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(0, -5), new Vector2(0, 5));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(aVec, bVec);
        distanceBetweenAToB = Mathf.Sqrt(Mathf.Pow(bVec.x - aVec.x, 2) + Mathf.Pow(bVec.y - aVec.y, 2));
    }
}
