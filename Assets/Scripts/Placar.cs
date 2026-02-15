using UnityEngine;

public class Placar : MonoBehaviour
{
    public int cafe;
    public Player player;
    public int points = 0;
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

    public void coletaCafe()
    {
        pontosTime++;
        points = +500;
    }

}
