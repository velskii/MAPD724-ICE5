using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;
    public Boundary boundary;
    public Boundary speeds;
    public AudioSource thunderSound;

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
        currentPosition += new Vector2(horizontalSpeed, verticalSpeed);
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
        float randomYposition = Random.Range(boundary.top, boundary.top + 3.0f);
        transform.position = new Vector2(randomXposition, randomYposition);
        verticalSpeed = Random.Range(speeds.bottom, speeds.top);
        horizontalSpeed = Random.Range(speeds.left, speeds.right);
    }
}