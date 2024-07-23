using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    bool go; // Will Be Used to Change Direction of Boomerang

    GameObject player; // Reference to the Main Character
    GameObject boomerang; // Reference to the Boomerang

    Transform itemToRotate; // The Weapon that is a child of the empty game object
    Vector3 locationInFrontOfPlayer; // Location in Front of Player to Travel to

    LineRenderer lineRenderer; // Draw the Path

    // User this for initialzation
    private void Start()
    {
        go = false; // Set to Not Return Yet

        player = GameObject.Find("Boomerang Boy"); // The GameObject to Return to
        boomerang = GameObject.Find("boomerang"); // The Weapon the Character is Holding in the Scene

        boomerang.GetComponent<MeshRenderer>().enabled = false; // Turn off the Mesh Render to Make the Weapon Invisible

        itemToRotate = gameObject.transform.GetChild(0); // Find the Weapon that is the Child of the Empty Object

        // Adjust the Location of the Player Accordingly, Here I Add to the Y position so that the Object Doesn't Go Too Low... Also Pick a Location In Front of the Player
        locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) + player.transform.forward * 9.5f;

        StartCoroutine(Boom()); // Now Start the Coroutine

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.useWorldSpace = true;
        lineRenderer.numCapVertices = 10;
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f); // Any Amount of Time you Want
        go = false;
    }

    // Update is called once per frame
    private void Update()
    {
        itemToRotate.transform.Rotate(0, 0, Time.deltaTime * 1000); // Rotate the Object

        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 10); // Change the Position to the Location In Front of the Player
            DrawLine(transform.position, locationInFrontOfPlayer);
        }

        if (!go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 10); // Return to Player
            DrawLine(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z + 1));
        }

        if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5)
        {
            // Once it is Close to the Player's Normal Weapon Visible, and Destroy the Clone
            boomerang.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }

    private void DrawLine(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
