using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    private float distance;
    [SerializeField] private float distanceThreshhold;
    [SerializeField] private float rotationAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //transform.position = Mathf.MoveTowards
        //    (transform.position, player.position, speed * Time.deltaTime);

        if (player)
        {
            distance = Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x, 2) + Mathf.Pow(player.position.y - transform.position.y, 2));

            if (distance > distanceThreshhold)
            {
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
                Destroy(player.gameObject);
            }
        }

    }

}
