using UnityEngine;

public class spawnCafe : MonoBehaviour
{
    public float time = 24f;
    public GameObject a;
    public bool morte;
    void Start()
    {
        Instantiate(a, transform.position, Quaternion.identity);
    }
    public void trueSpawn(bool morte)
    {
        this.morte = morte;
    }
    // Update is called once per frame
    void Update()
    {
        if (morte)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Instantiate(a, transform.position, Quaternion.identity);
                time = 24f;
                morte = false;
            }
        }

    }
}
