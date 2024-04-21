using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private float distance;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float startTime;
    [SerializeField]
    private float elapsedTime = 0f;

    void Start()
    {
        // save the current time as the start time
        startTime = Time.time;
    }

    void FixedUpdate()
    {

        // check if the elapsed time is greater than or equal to 1 second
        if (elapsedTime >= 1f)
        {
            // stop the object by setting the speed to zero
            speed = 0f;
        } else
        {
            // calculate the elapsed time
            elapsedTime = Time.time - startTime;

            distance = speed * Time.deltaTime;

            // move the object by speed * deltaTime in the forward direction
            transform.Translate(transform.right * distance, Space.World);
        }
    }
}
