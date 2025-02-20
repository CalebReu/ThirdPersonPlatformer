using UnityEngine;
using Unity.Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [Tooltip("How much the player can control their movement in the air as a fraction of their ground control.")]
    [SerializeField] private float airControlStrength;
    [SerializeField] private float jumpStrength;

    private Rigidbody rb;
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnSpacePressed.AddListener(Jump);
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.forward = playerCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);
        moveDirection = transform.TransformDirection(moveDirection);
        // if moving at max speed, set the component of moveDirection in the direction of movement to zero
        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0f;
        if (velocity.magnitude > maxSpeed && Vector3.Dot(velocity, moveDirection) > 0f)
        {
            Vector3 velocityDirection = velocity.normalized;
            moveDirection -= Vector3.Project(moveDirection, velocityDirection);
        }

        if (IsGrounded())
        {
            rb.AddForce(speed * moveDirection.normalized);
        }
        else
        {
            rb.AddForce(speed * airControlStrength * moveDirection.normalized);
        }
    }
    private void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.3f);
    }
}
