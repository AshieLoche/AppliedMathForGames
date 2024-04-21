using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private float distance;
    [SerializeField]
    private float time;
    [SerializeField]
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = speed * time;
        transform.position = new Vector3(distance, 0, 0);
    }
}
