using System;
using UnityEngine;
public class Bounce : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 baseDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = baseDir * 0.9f;
    }
}
