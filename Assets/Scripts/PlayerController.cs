using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float clampY;

    private Rigidbody rb;
    private PlayerInputConfig inputConfig;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputConfig = GetComponent<PlayerInputConfig>();
    }

    // Update is called once per frame
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
}