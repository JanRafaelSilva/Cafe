using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 movimento;

    public float velocidade = 5f;
    public float velMax = 1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movimento();
    }

    public void SetMovimento(InputAction.CallbackContext context)
    {
        movimento = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movimento * velocidade);
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, velMax);
    }
}
