using UnityEngine;

public class Projetil : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float force = 3;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        transform.Translate(Vector2.right * force * Time.deltaTime);
    }
    }
