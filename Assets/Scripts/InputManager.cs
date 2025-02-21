using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    public UnityEvent<Vector2> OnMove = new();
    public UnityEvent<Vector3> OnTurn = new();
    public UnityEvent OnSpacePressed = new();
    public UnityEvent OnResetPressed = new();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            input += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        OnMove?.Invoke(input);

        Vector3 direction = playerCamera.transform.forward;
        OnTurn?.Invoke(direction);
    }
}
