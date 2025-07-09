using UnityEngine;

public class KnobController : MonoBehaviour
{
    public BurnerController linkedBurner;
    public float activationAngle = 30f; // degrees required to turn on gas
    private float currentRotation;

    void Update()
    {
        currentRotation = transform.localEulerAngles.y;

        if (currentRotation > activationAngle && currentRotation < 270f) // so it won't rotate backwards or in circle
        {
            linkedBurner.SetGasFlow(true);
        }
        else
        {
            linkedBurner.SetGasFlow(false);
        }
    }
}
