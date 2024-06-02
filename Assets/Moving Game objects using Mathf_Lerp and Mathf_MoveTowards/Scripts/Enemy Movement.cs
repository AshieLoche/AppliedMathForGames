using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float catchArea;
    [SerializeField] private float rotationAngle;
    private float distance;
    private bool chase = true;
    private bool catched = false;
    public bool Catched { get { return catched; } }

    // Update is called once per frame
    void Update()
    {

        if (player && chase)
        {
            animator.SetTrigger("Chase");

            distance = Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x, 2) + Mathf.Pow(player.position.y - transform.position.y, 2));

            catched = distance < catchArea;

            if (!catched)
            {
                animator.SetBool("Attack", false);
                Vector3 direction = player.position - transform.position;
                rotationAngle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;

                spriteRenderer.flipY = direction.x < 0;

                direction.Normalize();

                Vector3 movement = speed * Time.deltaTime * direction;
                Quaternion rotation = Quaternion.Euler(0, 0, rotationAngle);

                transform.position += movement;
                transform.rotation = rotation;
            }
            else
            {
                StartCoroutine(Attack(0.6f));
            }
        }

    }

    private IEnumerator Attack(float waitTime)
    {
        chase = false;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(waitTime);
        animator.SetTrigger("Kill");
        Destroy(player.gameObject);
        yield return new WaitForSeconds(waitTime/6.0f);
        animator.ResetTrigger("Chase");
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Kill");
    }

}
