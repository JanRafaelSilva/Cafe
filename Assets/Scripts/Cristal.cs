using System;
using UnityEngine;

public class Cristal : MonoBehaviour, IDamageable
{
    public int vida = 150;
    GameObject Placar;
    public GameObject spawn;
    public bool pode = true;
    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        Placar = GameObject.FindGameObjectWithTag("Placar");
    }
    private void Update()
    {
        if(vida == 0)
        {
            var control = spawn.gameObject.GetComponent<spawnCafe>();
            control.trueSpawn(pode);
            var controle = Placar.gameObject.GetComponent<Placar>();
            controle.coletaCafe(500);
            Destroy(gameObject);
        }
    }
    public void TomarDano(int dano)
    {
        vida -= dano;
    }
}
