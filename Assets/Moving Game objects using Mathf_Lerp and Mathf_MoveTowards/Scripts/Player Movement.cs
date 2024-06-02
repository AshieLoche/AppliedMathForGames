using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //[SerializeField] private Transform up;
    //[SerializeField] private Transform down;
    //[SerializeField] private Transform left;
    //[SerializeField] private Transform right;
    //[SerializeField] private Transform dash;
    //[SerializeField] private float speed;
    //[SerializeField] private float dashSpeed;

    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private GameObject sprite;
    [SerializeField] private Transform spriteTransform;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform walkWaypoint;
    [SerializeField] private Transform dashWayPoint;
    [SerializeField] private Vector3 dashPosition;
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private bool dashing = false;
    private Vector3 movement;
    private int axis;

    private void Start()
    {
        spriteTransform = sprite.transform;
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        animator = sprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashing = true;
            dashPosition = dashWayPoint.position;
        }

        if (dashing && !enemyMovement.Catched)
        {
            animator.SetBool("Run", true);
            animator.speed = 2.5f;
            movement = (axis == 0) ? new Vector3(Mathf.Lerp(transform.position.x, dashPosition.x, dashSpeed * Time.deltaTime), transform.position.y, 0.0f) : new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, dashPosition.y, dashSpeed * Time.deltaTime), 0.0f);
            transform.position = movement;
            StartCoroutine(Dash());
        }
        else
        {
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !enemyMovement.Catched)
            {
                animator.SetBool("Run", true);

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    axis = 1;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                    spriteRenderer.flipY = false;
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    axis = 1;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
                    spriteRenderer.flipY = false;
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    axis = 0;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                    spriteRenderer.flipY = true;
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    axis = 0;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                    spriteRenderer.flipY = false;
                }

                Move();
            }
            else
            {
                animator.SetBool("Run", false);
            }
        }

    }

    private void Move()
    {
        movement = (axis == 0) ? new Vector3(Mathf.MoveTowards(transform.position.x, walkWaypoint.position.x, speed * Time.deltaTime), transform.position.y, 0.0f) : new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, walkWaypoint.position.y, speed * Time.deltaTime), 0.0f);
        transform.position = movement;
    }

    IEnumerator Dash()
    {
        yield return new WaitUntil(() => enemyMovement.Catched || Mathf.Abs(transform.position.x - dashPosition.x) <= 1f || Mathf.Abs(transform.position.y - dashPosition.y) <= 1f);
        animator.SetBool("Run", false);
        yield return new WaitUntil(() => enemyMovement.Catched || transform.position == dashPosition);
        dashing = false;
        animator.speed = 1;
    }
}
