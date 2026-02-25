using UnityEngine;

public class SpawnChaleira : MonoBehaviour
{
    public float time = 12f;
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
                time = 12f;
                morte = false;
            }
        }

    }
}
