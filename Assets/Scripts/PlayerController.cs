using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float clampY;
    public int player;
    public PlayerInputConfig inputConfig;

    private Rigidbody rb;
    private AudioSource sfxAudio;

    void Start()
    {
        sfxAudio = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        inputConfig = GetComponent<PlayerInputConfig>();
    }

    private void FixedUpdate()
    {
        float verticalInput = 0f;

        if (Input.GetKey(inputConfig.upKey))
        {
            verticalInput = 1f;
        }
        if (Input.GetKey(inputConfig.downKey))
        {
            verticalInput = -1f;
        }

        Vector3 movement = new Vector3(0f, verticalInput, 0f);

        rb.velocity = movement * moveSpeed;

        Vector3 clampedPosition = rb.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -clampY, clampY);
        rb.position = clampedPosition;

    }

    private void OnCollisionEnter(Collision collision)
    {
        sfxAudio.Play();
    }
}