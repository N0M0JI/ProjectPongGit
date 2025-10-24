using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    
    public PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }


    public void Move()
    {
        Vector2 dir = controls.Player.Move.ReadValue<Vector2>();

        rb.linearVelocity = dir * speed;
    }


    void Update()
    {
        Move();
    }
}
