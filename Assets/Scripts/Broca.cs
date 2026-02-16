using UnityEngine;

public class Broca : MonoBehaviour
{
    public int dano = 50;

    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamageable objetoDano = collision.GetComponent<IDamageable>();

        if (objetoDano != null)
        {
            objetoDano.TomarDano(dano);
            gameObject.SetActive(false);
        }
    }
}