using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    public float distanceBetweenEnemyToPlayer;
    public Transform enemyTrans;
    [Range(0f, 5f)]
    public float radius;
    public bool isInside = false;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 enemyOrigin = enemyTrans.position;

        distanceBetweenEnemyToPlayer = Mathf.Sqrt(Mathf.Pow(enemyOrigin.x - origin.x, 2) + Mathf.Pow(enemyOrigin.y - origin.y, 2));

        isInside = radius > distanceBetweenEnemyToPlayer;
        Handles.color = isInside? Color.red : Color.green;
        Handles.DrawWireDisc(origin, new Vector3 (0, 0, 1), radius);
    }
#endif
}
