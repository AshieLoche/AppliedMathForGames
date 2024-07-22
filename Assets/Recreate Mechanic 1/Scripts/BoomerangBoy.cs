using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBoy : MonoBehaviour
{
    public GameObject boomer;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone;
            clone = Instantiate(boomer, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
        }
    }
}
