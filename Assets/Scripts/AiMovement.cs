using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Transform Ballposition;
    public Vector2 Balldir;
    private Vector2 Ballpos;
    void Start()
    {
        Ballpos = new Vector2(Ballposition.position.x, Ballposition.position.y);
    }

    void Move(Vector2 targetPosition)
    {
        float stopDistance = 0.1f; 
        Vector2 delta = targetPosition - rb.position;

        if (delta.magnitude <= stopDistance)
        {
            rb.linearVelocity = Vector2.zero; 
        }
        else
        {
            Vector2 direction = delta.normalized;
            rb.linearVelocity = direction * speed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(rb.position, CalculatePointImpact(Balldir, Ballpos));
    }

    public Vector2 CalculatePointImpact(Vector2 ballDir, Vector2 ballPos)
    {
        if (Mathf.Abs(ballDir.x) < 0.0001f)
            return rb.position;

        float t = (rb.position.x - ballPos.x) / ballDir.x; 
        if (t < 0)
            return rb.position; 

        Vector2 pointImpact = ballPos + ballDir.normalized * (ballDir.magnitude * t);
        return pointImpact;
    }

    void Update()
    {
        Move(CalculatePointImpact(Balldir, Ballpos));
    }
}
