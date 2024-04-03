using UnityEngine;

public class WheelParticleHandler : MonoBehaviour
{
    float particleEmissionRate = 0;

    //TopDownCarController topDownCarController;
    Car car;

    ParticleSystem particleSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;

    private void Awake()
    {
        //topDownCarController = GetComponentInParent<TopDownCarController>();
        car = GetComponentInParent<Car>();

        particleSystemSmoke = GetComponentInParent<ParticleSystem>();

        particleSystemEmissionModule = particleSystemSmoke.emission;

        particleSystemEmissionModule.rateOverTime = 0;
    }


    private void Update()
    {
        particleEmissionRate = Mathf.Lerp(particleEmissionRate, 0, Time.deltaTime * 5.0f);
        particleSystemEmissionModule.rateOverTime = particleEmissionRate;

        //if (topDownCarController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        if (car.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            if (isBraking)
            {
                particleEmissionRate = 60.0f;
            } else
            {
                particleEmissionRate = Mathf.Abs(lateralVelocity) * 2.0f;
            }
        }
    }
}
