using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class Tocha : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("aqui");
            Destroy(this.gameObject);
            var controle = Player.GetComponent<Player>();
            controle.Ntochas--;
            
        }
    }
}
