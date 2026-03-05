using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MarioController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;

    private Rigidbody rb;
    private bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Congela rotación y eje Z por código también
        rb.constraints = RigidbodyConstraints.FreezeRotation |
                         RigidbodyConstraints.FreezePositionZ;
    }

    private void Update()
    {
        float horizontal = 0f;

        if (Keyboard.current.rightArrowKey.isPressed)
            horizontal = 1f;

        if (Keyboard.current.leftArrowKey.isPressed)
            horizontal = -1f;

        // Movimiento horizontal manteniendo velocidad Y de la física
        rb.linearVelocity = new Vector3(horizontal * speed, rb.linearVelocity.y, 0f);

        // Salto
        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}