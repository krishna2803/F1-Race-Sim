using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTrailHandler : MonoBehaviour
{
    //TopDownCarController topDownCarController;
    Car car;
    TrailRenderer trailRenderer;

    private void Awake()
    {
        //topDownCarController = GetComponentInParent<TopDownCarController>();
        car = GetComponentInParent<Car>();
        trailRenderer = GetComponentInParent<TrailRenderer>();
        trailRenderer.emitting = false;
    }

    private void Update()
    {
        if (car.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            trailRenderer.emitting = true;
        } else
        {
            trailRenderer.emitting = false;
        }
    }
}
