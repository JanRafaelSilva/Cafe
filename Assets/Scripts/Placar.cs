using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Placar : MonoBehaviour
{
    public int cafe;
    public Player player;
    public int points = 1000;
    public int pontosTime;
    public float time = 60f;

    void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if(pontosTime == 2)
        {
            time += 30f;
            pontosTime = 0;
        }
        
    }
    public void coletaCafe(int quantidade)
    {
        cafe++;
        pontosTime++;
        points += quantidade;
    }

}
