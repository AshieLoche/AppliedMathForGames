using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform up;
    [SerializeField] private Transform down;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 movement = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, up.position.y, speed * Time.deltaTime), 0.0f);
            sprite.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            spriteRenderer.flipX = false;
            transform.position = movement;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 movement = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, down.position.y, speed * Time.deltaTime), 0.0f);
            sprite.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            spriteRenderer.flipX = false;
            transform.position = movement;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 movement = new Vector3(Mathf.MoveTowards(transform.position.x, left.position.x, speed * Time.deltaTime), transform.position.y, 0.0f);
            sprite.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            spriteRenderer.flipX = true;
            transform.position = movement;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 movement = new Vector3(Mathf.MoveTowards(transform.position.x, right.position.x, speed * Time.deltaTime), transform.position.y, 0.0f);
            sprite.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            spriteRenderer.flipX = false;
            transform.position = movement;
        }

    }
}
