using UnityEngine;

public class SpawnChaleira : MonoBehaviour
{
    public float time = 120f;
    public GameObject a;
    public bool spawn = false;
    void Start()
    {
        Instantiate(a, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Instantiate(a, transform.position, Quaternion.identity);
                time = 120f;
            }
        }

    }
}
