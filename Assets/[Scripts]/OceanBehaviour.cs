using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {

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
        transform.position = new Vector2(0.0f, boundary.top);
    }
}