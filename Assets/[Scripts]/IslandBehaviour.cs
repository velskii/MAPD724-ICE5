using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public Boundary boundary;
    public AudioSource yaySound;

    // Start is called before the first frame update
    void Start()
    {
        ResetObject();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Checkbounds();
    }

    public void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition += new Vector2(0.0f, verticalSpeed);
        transform.position = currentPosition;
    }

    public void Checkbounds()
    {
        if (transform.position.y < boundary.bottom)
        {
            ResetObject();
        }
    }

    public void ResetObject()
    {
        float randomXposition = Random.Range(boundary.left, boundary.right);
        transform.position = new Vector2(randomXposition, boundary.top);
    }
}