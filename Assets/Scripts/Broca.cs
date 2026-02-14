using UnityEngine;

public class Broca : MonoBehaviour
{
    public int dano = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {//colocar tag do inimigo    VV
        if (collision.CompareTag(""))
        {
            //fazer inimigo tomar dano
        }
    }
}
