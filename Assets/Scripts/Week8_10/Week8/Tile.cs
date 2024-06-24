using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool current;
    public bool target;
    public bool selectable;
    public bool walkable;

    // Needed for BFS
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;

    public List<Tile> adjacentTiles = new List<Tile>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void ResetValues()
    {
        current = false;
        target = false;
        selectable = false;

        visited = false;
        parent = null;
        distance = 0;
        
        adjacentTiles.Clear();
    }

    public void FixedUpdate()
    {
        ResetValues();
    }

    public void CheckTiles(Vector3 direction, float jumpHeight)
    {
        Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight)/2, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider collider in colliders)
        {
            Tile tile = collider.GetComponent<Tile>();

            if (tile != null && tile.walkable)
            {
                RaycastHit hit;

                if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
                {
                    adjacentTiles.Add(tile);
                }
            }
        }
    }
}
