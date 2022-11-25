using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    Rigidbody rb;
    public RoadSpawner rs;
    public float gravity = 100f;
    public float forwardSpeed = 10f;
    public float moveZ;
    public float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rs = GameObject.Find("RoadSpawner").GetComponent<RoadSpawner>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            moveZ -= moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            moveZ += moveSpeed * Time.deltaTime;
        }
        

        if(transform.position.y < -3f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(forwardSpeed, 0f, moveZ);
        rb.AddForce(new Vector3(0f, -gravity, 0f) * rb.mass);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Create")
        {
            rs.MakeRoad();
        }
    }
}
