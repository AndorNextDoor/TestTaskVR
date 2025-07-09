using UnityEngine;

public class BurnerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem flameEffect;
    [SerializeField] private ParticleSystem gasEffect;

    public bool IsGasOn { get; private set; }
    public bool IsFlameOn { get; private set; }

    public void SetGasFlow(bool on)
    {
        IsGasOn = on;

        if (gasEffect != null)
        {
            if (on && !IsFlameOn)
                gasEffect.Play();
            else
                gasEffect.Stop();
        }
    }

    public void TryIgnite()
    {
        if (IsGasOn && !IsFlameOn)
        {
            IsFlameOn = true;
            flameEffect?.Play();
            gasEffect?.Stop();
        }
    }

    public void Extinguish() 
    {
        IsFlameOn = false;
        flameEffect?.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Match"))
        {
            MatchController match = other.GetComponent<MatchController>();
            if (match != null && match.IsLit)
            {
                TryIgnite();
            }
        }
    }
}
