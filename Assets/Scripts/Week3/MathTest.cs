using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour
{
    public float magnitude, speed;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(startPos.x, startPos.y + PingPongAmount() * SineAmount(), startPos.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(startPos, 0.25f);
    }

    public float PingPongAmount()
    {
        return Mathf.PingPong(speed * Time.time, magnitude);
    }

    public float SineAmount()
    {
        return Mathf.Sin(Time.time * speed);
    }
}
