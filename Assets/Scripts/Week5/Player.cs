using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += 100.0f * Time.deltaTime * transform.right;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += 100.0f * Time.deltaTime * -transform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.forward, Time.deltaTime * 200.0f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.forward, Time.deltaTime * -200.0f);
        }

        Debug.DrawRay(transform.position, transform.right * 5.0f, Color.blue);
        
    }
}
