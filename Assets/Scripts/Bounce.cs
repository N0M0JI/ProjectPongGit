using System;
using UnityEngine;
public class Bounce : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 dir;
    public float speed;
    public AudioSource audio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        dir = Vector2.Reflect(dir, contact.normal);
        audio.Play();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = dir * speed;
    }
}
