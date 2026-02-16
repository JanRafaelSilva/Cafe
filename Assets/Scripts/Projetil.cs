using UnityEngine;

public class Projetil : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float force = 5;
    public int b;
    public int dano = 100;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        transform.Translate(Vector2.right * force * Time.deltaTime * b);
    }
    public void direcao(int a)
    {
        b = a;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chaleira"))
        {
            var objetoDano = collision.collider.GetComponent<InChaleira>();

            if (objetoDano != null)
            {
                objetoDano.TomarDano(dano);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Toupeira"))
        {
            var objetoDano = collision.collider.GetComponent<InToupeiras>();

            if (objetoDano != null)
            {
                objetoDano.controleVida(dano);
                Destroy(gameObject);
            }
        }
        }
}
