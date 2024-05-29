using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector3 lastSeen;
    Vector3 target;

    public GameObject player;
    public float viewDistance;
    public float viewAngle;

    // Start is called before the first frame update
    void Start()
    {
        lastSeen = transform.position;
        target = player.transform.position;
    }

    bool SeePlayer()
    {
        Vector3 dir = player.transform.position - transform.position;

        if (dir.magnitude < viewDistance)
        {
            Debug.DrawRay(transform.position, transform.right * viewDistance, Color.yellow, 0);
            Debug.DrawRay(transform.position, dir.normalized * viewDistance, Color.yellow, 0);
            float angle = Vector3.Dot(transform.right, dir.normalized);

            if ((Mathf.Acos(angle) * Mathf.Rad2Deg) < viewAngle)
            {
                return true;
            }

        }

        return false;

    }

    // Update is called once per frame
    void Update()
    {

        bool seen = SeePlayer();

        if (seen)
        {
            lastSeen = player.transform.position;
            target = lastSeen;
        }

        // When we reach our target
        if (Vector3.Distance(transform.position, target) < 0.5f)
        {
            // At target, pick up new spot to go to
            Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
            target = lastSeen + (rotation * transform.right * 5.0f);
        }
        else
        {
            Vector3 dir = target - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion p = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * 10.0f);

            transform.position += 5.0f * Time.deltaTime * transform.right;
        }

        Debug.DrawRay(transform.position, transform.right * viewDistance, seen? Color.red : Color.yellow, 0);
        Quaternion rayAngle = Quaternion.Euler(0, 0, -viewAngle);
        Debug.DrawRay(transform.position, rayAngle * transform.right * viewAngle, seen ? Color.red : Color.yellow);
        rayAngle = Quaternion.Euler(0, 0, viewAngle);
        Debug.DrawRay(transform.position, rayAngle * transform.right * viewAngle, seen ? Color.red : Color.yellow);

    }
}
