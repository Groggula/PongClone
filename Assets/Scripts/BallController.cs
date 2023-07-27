using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float knockbackForce;

    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerOne");
    }

    void FixedUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.AddForce(direction * speed);
    }
}
