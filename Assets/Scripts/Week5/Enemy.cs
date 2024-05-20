using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector3 lastSeen;
    Vector3 target;

    public GameObject player;
    public float ViewDistance;
    public float ViewAngle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lastSeen = transform.position;
        target = player.transform.position;
        // When we reach our target
        if (Vector3.Distance(lastSeen, target) < 0.5f)
        {
            // At target, pick up new spot to go to
            Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
            target = lastSeen + (rotation * transform.up * 5.0f);
        }
        else
        {
            Vector3 dir = target - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion p = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * 10.0f);

            transform.position += 5.0f * Time.deltaTime * transform.right;
        }

        Debug.DrawRay(transform.position, transform.right * 5.0f, Color.yellow);

    }
}
