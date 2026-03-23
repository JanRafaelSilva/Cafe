using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InChaleira : MonoBehaviour, IDamageable
{
    public Transform DetectaChao;//Avaliar se a chão a frente
    public Transform Parede;//Avaliar se a chão a frente
    public float distancia = 3;// tamanho do raio do Raycast
    public bool olhandoParaDireita;// irá verificar para qual lado o nosso inimigo está olhando
    float velocidade = 1f;// irá definir a velocidade em que o nosso inimigo irá se movimentar
    float velocidadePerseguicao = 3f;// 

    public bool spot = false; //booleana para saber se o jogador esta dentro do campo de visão
    public bool spot2 = false; //booleana para saber se o jogador esta dentro do campo de visão
    public bool spot3 = false;
    public Transform target; //alvo que o inimigo vai perseguir, nesse caso o jogador
    public Transform fimCP; //final do campo de visão 
    public Transform fimCP2; //final do campo de visão 
    private GameObject Player;
    private Animator MuAnim;
    bool atacando;
    public float vida = 75;
    public GameObject spawn;
    public bool pode = true;
   
    void Start()
    {
        olhandoParaDireita = true; // vai começar olhando para direita
        Player = GameObject.FindGameObjectWithTag("Player");
        MuAnim = GetComponent<Animator>();
        spawn = GameObject.FindGameObjectWithTag("Spawn");
    }


    void FixedUpdate()
    {
        Patrulha();
        Raycasting();
        Persegue();
    }
    public void Patrulha()
    {
        if (atacando == false)
        {


            //MuAnim.SetBool("Correndo", false);
            //MuAnim.SetBool("Andando", true);
            //MuAnim.SetBool("Atacando", false);
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);// desloca para frente pelo transform

            RaycastHit2D groundInfo = Physics2D.Raycast(DetectaChao.position, Vector2.down, distancia, 1 << LayerMask.NameToLayer("Ground"));
            RaycastHit2D WallInfo = Physics2D.Raycast(Parede.position, Vector2.right, distancia, 1 << LayerMask.NameToLayer("Wall"));
            /*
             RaycastHit2D contem informações do que aconteceu com a matriz
           RaycastHit2D avalia o Collider2D detectado no Raio determinado e atua como um indicador de groundInfo, groundInfo é boleana e vai retornar true se
           Physics2D.Raycast encostar em algo ou false se não tocar em nada, no caso DetectaChao.position: se o ele ainda está colidindo com esse objeto, Vector2.down: avalia a direção do raio.
           */

            if (groundInfo.collider == false)// se o  Physics2D.Raycast não estiver colidindo mais com o chao
            {
                if (olhandoParaDireita == true)// e estiver olhando para direita
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);// vai virar o inimigo em 180 graus
                    olhandoParaDireita = false;// então ele passara a andar para a esquerda;
                }
                else// se estiver olhando para esquerda e a não tiver mais colisão 
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);// vai voltar a olhar para direita
                    olhandoParaDireita = true;
                }
            }
            else if (spot2 == true)
            {
                if (olhandoParaDireita == true)// e estiver olhando para direita
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);// vai virar o inimigo em 180 graus
                    olhandoParaDireita = false;// então ele passara a andar para a esquerda
                }
                else
                {
                        transform.eulerAngles = new Vector3(0, 0, 0);// vai virar o inimigo em 180 graus
                        olhandoParaDireita = true;// então ele passara a andar para a esquerda
                }
            }
            else if(WallInfo.collider == true)
            {
                if (olhandoParaDireita == true)// e estiver olhando para direita
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);// vai virar o inimigo em 180 graus
                    olhandoParaDireita = false;// então ele passara a andar para a esquerda;
                }
                else// se estiver olhando para esquerda e a não tiver mais colisão 
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);// vai voltar a olhar para direita
                    olhandoParaDireita = true;
                }
            }
        
    }
    }

    public void Raycasting()
    {

        Debug.DrawLine(transform.position, fimCP.position, Color.green);
        // apenas uma forma de visualizar o funcionamento da visão do inimigo
        spot = Physics2D.Linecast(transform.position, fimCP.position, 1 << LayerMask.NameToLayer("Player"));
        /*spot recebe true ou false, true se o Player estiver no Raio,  Physics2D.Linecast é uma linha imaginaria que detecta qualquer contato com essa linha,
         LayerMask ta determinando uma restrição de camada para o a detectação
         1 << LayerMask.NameToLayer("Player"): ta gerando uma máscara derivada da LayerMask do Player
        */
        spot2 = Physics2D.Linecast(transform.position, fimCP2.position, 1 << LayerMask.NameToLayer("Player"));
    }

    public void Persegue()
    {
        spot3 = Physics2D.Linecast(DetectaChao.position, new Vector2((olhandoParaDireita == true ? transform.position.x + 2f : transform.position.x + 1f * -1f), transform.position.y + 2f), 1 << LayerMask.NameToLayer("Player"));
        Debug.DrawLine(DetectaChao.position, new Vector2((olhandoParaDireita == true ? transform.position.x + 2f : transform.position.x + 1f * -1f), transform.position.y + 2f), Color.red);
        if (spot == true && atacando == false)
        {
            //MuAnim.SetBool("Correndo", true);
            //MuAnim.SetBool("Andando", false);
            //MuAnim.SetBool("Atacando", false);
            velocidade = velocidadePerseguicao;
        }

        else if (spot == false)
        {
            atacando = false;
            velocidade = 1f;
        }
        /*if (spot3)
        {
            atacando = true;
            //MuAnim.SetBool("Correndo", false);
            //MuAnim.SetBool("Andando", false);
            //MuAnim.SetBool("Atacando", true);
        }*/
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            var controle = collision.gameObject.GetComponent<Player>();
            if (controle != null)
            {
                // collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15f), ForceMode2D.Impulse);
                //controle.controleVida(-15);
            }
        }
    }

    public void TomarDano(int quantidade)
    {
        vida -= quantidade;

        if (vida <= 0)
        {
            GameObject Placar = GameObject.FindGameObjectWithTag("Placar");
            var control = Placar.gameObject.GetComponent<Placar>();
            control.coletaCafe(500);
            var controle = spawn.gameObject.GetComponent<SpawnChaleira>();
            controle.trueSpawn(pode);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
