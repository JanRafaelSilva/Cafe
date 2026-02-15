using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 movimento;

    public bool isGrounded;

    public float velocidade = 5f;
    public float velMax = 5f;
    public float puloForce = 5f;
    public float controleNoAr = 0.2f;
    public float frenagem = 10f;

    Animator anim;

    public GameObject brocaHB;
    public bool broca;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        HandleAnimation();
        HandleFlip();
    }

    private void FixedUpdate()
    {
        Movimento();
    }

    public void SetMovimento(InputAction.CallbackContext context)
    {
        movimento = context.ReadValue<Vector2>();
    }

    public void SetPulo(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, puloForce);
            isGrounded = false;
        }
    }

    public void SetBroca(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            broca = true;
        }
    }

    void Movimento()
    {
        float forcaFinal = isGrounded ? velocidade : (velocidade * controleNoAr);

        if (movimento.x != 0)
        {
            rb.AddForce(new Vector2(movimento.x * forcaFinal, 0));
        }
        else if (isGrounded)
        {
            float novaVelX = Mathf.MoveTowards(rb.linearVelocity.x, 0, frenagem * Time.fixedDeltaTime);
            rb.linearVelocity = new Vector2(novaVelX, rb.linearVelocity.y);
        }

        float xLimitado = Mathf.Clamp(rb.linearVelocity.x, -velMax, velMax);
        rb.linearVelocity = new Vector2(xLimitado, rb.linearVelocity.y);
    }

    void HandleAnimation()
    {
        if (!isGrounded)
        {
            anim.SetBool("isGrounded", false);
        }
        else
        {
            anim.SetBool("isGrounded", true);
        }

        if (!broca)
        {
            anim.SetBool("broca", false);
        }
        else
        {
            anim.SetBool("broca", true);
        }
    }

    void HandleFlip()
    {
        if (movimento.x > 0.1f)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (movimento.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Broca()
    {
        if (broca)
        {
            brocaHB.SetActive(true);
            broca = false;
        }
        else
        {
            brocaHB.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}