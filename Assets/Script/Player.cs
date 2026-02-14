using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.IO.Compression;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 movimento;
    public float velocidade = 10f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetMovimento(InputAction.CallbackContext context)
    {
        movimento = context.ReadValue<Vector2>();
    }
    public void Movimento()
    {
        rb.linearVelocity = new Vector2(movimento.x * velocidade * Time.fixedDeltaTime, movimento.y);
    }
    void FixidUpdate()
    {
         Movimento();
    }
}
