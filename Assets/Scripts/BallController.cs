using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float knockbackForce;

    private Rigidbody rb;
    private Vector2 initialDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialDirection = RandomVector(-1f, 1f).normalized;
        rb.velocity = initialDirection * speed;
    }

    void Update()
    {
        if (transform.position.x > 15 || transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    private Vector2 RandomVector(float min, float max)
    {
        return new Vector2(Random.Range(min, max), Random.Range(min, max));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 collisionNormal = collision.contacts[0].normal;
        Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, collisionNormal);
        rb.velocity = reflectedVelocity.normalized * speed;

        if (collision.gameObject.name == "PlayerOne")
        {
            Debug.Log("Player 1 hit ball");
        }
        else if (collision.gameObject.name == "PlayerTwo")
        {
            Debug.Log("Player 2 hit ball");
        }
    }
}
