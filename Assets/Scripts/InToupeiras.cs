using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class InToupeiras : MonoBehaviour
{
    public bool spot;
    public Transform my;
    float angulo = 0;
    public float x;
    public float y;
    public int vida = 20;
    Animator anima;
    public bool atacando = false;
    public void Awake()
    {
        my = GetComponent<Transform>();
        angulo = transform.rotation.eulerAngles.z;
        anima = GetComponent<Animator>();
    }
    public void Start()
    {
        //my.rotation = Quaternion.Euler(0, 0, angulo);
        switch (angulo)
        {
            case 0:
                y = 3;
            break;
            case 90:
                x = -3;
            break;
            case 180:
                y = -3;
            break;
            case 270:
                x = 3;
            break;
        }
    }
    public void Update()
    {
        Raycasting();
        if (spot)
        {
            anima.SetBool("Atacando", false);
            anima.SetBool("Ativado", true);
            anima.SetBool("Escondido", false);
            atacando = true;
        }
    }
    public void Raycasting(){
        Debug.DrawLine(this.transform.position, new Vector2(transform.position.x + x, transform.position.y + y), Color.green);
        spot = Physics2D.Linecast(this.transform.position, new Vector2(transform.position.x + x, transform.position.y + y), 1 << LayerMask.NameToLayer("Player"));
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            var controle = collision.gameObject.GetComponent<Player>();
            if (controle != null)
            {
                //  controle.controleCafe(-5);
                if (atacando == true)
                {
                    anima.SetBool("Atacando", true);
                    anima.SetBool("Ativado", true);
                    anima.SetBool("Escondido", false);
                }
            }
        }
    }
    public void controleVida(int dano)
    {
        vida += dano;
    }
}
