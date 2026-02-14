using UnityEngine;
using UnityEngine.InputSystem;

public class Luz : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D myLight;
    [SerializeField] private float rangeIncrease = 0.05f;
    [SerializeField] private float minRange = 3f;
    [SerializeField] private float maxRangeOuter = 8f;
    [SerializeField] private float maxRangeInner = 24.5f;
    private void Awake()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }
    public void SetLuz(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            myLight.pointLightOuterRadius = Mathf.Clamp(myLight.pointLightOuterRadius + rangeIncrease, minRange, maxRangeOuter);
        }
    }
}
