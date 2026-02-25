using UnityEngine;
using UnityEngine.Rendering.Universal;
public class luz : MonoBehaviour
{
    public Light2D l;
    [SerializeField] private float rangeIncrease = 0.05f;
    [SerializeField] private float rangeIncrease2 = 0.10f;
    [SerializeField] private float rangeIncrease3 = 0.15f;
    [SerializeField] private float minRange = 2f;
    [SerializeField] private float maxRangeOuter = 2f;
    [SerializeField] private float maxRangeOuter2 = 2.10f;
    [SerializeField] private float maxRangeOuter3 = 2.15f;
    //  [SerializeField] private float maxRangeInner = 24.5f;
    void Awake()
    {
        l = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        
    }

    // Update is called once per frame
    public void Luz(int MK)
    {
        switch (MK) 
        {
            case 1:
        l.pointLightOuterRadius = Mathf.Clamp(l.pointLightOuterRadius + rangeIncrease, minRange, maxRangeOuter);
                break;
            case 2:
                
                l.pointLightOuterRadius = Mathf.Clamp(l.pointLightOuterRadius + rangeIncrease2, minRange, maxRangeOuter2);
                break;
            case 3:
                
                l.pointLightOuterRadius = Mathf.Clamp(l.pointLightOuterRadius + rangeIncrease3, minRange, maxRangeOuter3);
                break;
        }
    }
}
