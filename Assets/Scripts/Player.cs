using UnityEngine;
using Unity.Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private float speed;
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
        rb.AddForce(speed * moveDirection);
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
    }
}
