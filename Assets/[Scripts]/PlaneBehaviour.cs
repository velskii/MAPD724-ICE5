using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{
    public Boundary boundary;
    public Camera camera;

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
        foreach (var touch in Input.touches)
        {
            //GameObject.FindGameObjectWithTag("camera").GetComponent<Camera>()
            // Vector2 touchPosition = new Vector2(GetComponent<Camera>().ScreenToWorldPoint(touch.position).x, -4.0f);
            Vector2 touchPosition = new Vector2(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(touch.position).x, -4.0f);
            transform.position = touchPosition;
        }
    }


    public void Checkbounds()
    {
        // right bounds
        if (transform.position.x > boundary.right)
        {
            transform.position = new Vector2(boundary.right, -4.0f);
        }
        // left  bounds
        if (transform.position.x < boundary.left)
        {
            transform.position = new Vector2(boundary.left, -4.0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cloud"))
        {
            other.gameObject.GetComponent<CloudBehaviour>().thunderSound.Play();
        }

        if (other.gameObject.CompareTag("Island"))
        {
            other.gameObject.GetComponent<IslandBehaviour>().yaySound.Play();
        }
    }
}