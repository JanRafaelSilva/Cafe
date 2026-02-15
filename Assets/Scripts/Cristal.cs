using UnityEngine;

public class Cristal : MonoBehaviour
{
    public int vida = 150;
    GameObject Placar;
    private void Awake()
    {
        Placar = GameObject.FindGameObjectWithTag("Placar");
    }
    private void Update()
    {
        if(vida == 0)
        {
            var controle = Placar.gameObject.GetComponent<Placar>();
            controle.coletaCafe();
            Destroy(gameObject);
        }
    }
    public void controleVida(int dano)
    {
        vida += dano;
    }
}
