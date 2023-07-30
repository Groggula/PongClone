using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float knockbackForce;
    public int playerNumber = -1;

    private Rigidbody rb;
    private Vector2 initialDirection;
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        rb = GetComponent<Rigidbody>();
        initialDirection = RandomVector(-1f, 1f).normalized;
        rb.velocity = initialDirection * speed;
    }

    void Update()
    {
        if (transform.position.x > 15 || transform.position.x < -15)
        {
            Destroy(gameObject);
            spawnManager.onBallDestroy();
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

        IPowerUp powerUp = collision.gameObject.GetComponent<IPowerUp>();

        if (collision.gameObject.CompareTag("PlayerOne"))
        {
            playerNumber = 1;
        }
        else if (collision.gameObject.CompareTag("PlayerTwo"))
        {
            playerNumber = 2;
        }

        if (powerUp != null)
        {
            FindObjectOfType<PowerUpManager>().HandlePowerUpCollision(powerUp, playerNumber);
            Debug.Log("PowerUp hit by" + playerNumber);
            
        }
    }
}
