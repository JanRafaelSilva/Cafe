using UnityEngine;

public class Broca : MonoBehaviour
{
    public int dano = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable objetoDano = collision.GetComponent<IDamageable>();

        if (objetoDano != null)
        {
            objetoDano.TomarDano(dano);
        }
    }
}