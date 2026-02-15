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
    public int points = 0;
    public int pontosTime;
    public float time = 60f;
    public Light2D luz;
    [SerializeField] private float rangeIncrease;
    [SerializeField] private float minRange = 3f;
    [SerializeField] private float maxRangeOuter = 8f;
    [SerializeField] private float maxRangeInner = 24.5f;

    void Awake()
    {
        player = GetComponent<Player>();
        luz = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
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
    public void queimaCafe(float tempo)
    {
        if(tempo == 4f) {
            rangeIncrease = 0.15f;
            luz.pointLightOuterRadius = Mathf.Clamp(luz.pointLightOuterRadius + rangeIncrease, minRange, maxRangeOuter);
        }
        if(tempo == 2f) {
            rangeIncrease = 0.10f;
            luz.pointLightOuterRadius = Mathf.Clamp(luz.pointLightOuterRadius + rangeIncrease, minRange, maxRangeOuter);
        }
        if(tempo == 1f) {
            rangeIncrease = 0.05f;
            luz.pointLightOuterRadius = Mathf.Clamp(luz.pointLightOuterRadius + rangeIncrease, minRange, maxRangeOuter);
        }
    }
    public void coletaCafe()
    {
        cafe++;
        pontosTime++;
        points = +500;
    }

}
