/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using System;
using UnityEngine;

public class AvoidanceProcessor : MonoBehaviour
{
    private const float kEpsilon = 0.00001f;
    private const float kScaling = 1.5f;
    private const float kExponentialCutoff = 3f;
    private const float kPowerLawExponent = 2f;

    private UnitComponent mUnitComponent;

    internal void Initialize()
    {
        mUnitComponent = GetComponent<UnitComponent>();
    }

    internal void Tick()
    {
        mUnitComponent.Acceleration = (mUnitComponent.Direction * mUnitComponent.Speed);

        foreach (UnitComponent neighbor in mUnitComponent.Neighbors)
        {
            float distanceSq = (neighbor.transform.position - mUnitComponent.transform.position).sqrMagnitude;
            float radiusSq = Mathf.Sqrt(neighbor.AwarenessSphere.radius + mUnitComponent.AwarenessSphere.radius);
            if (distanceSq != radiusSq)
            {
                Vector3 w = neighbor.transform.position - mUnitComponent.transform.position;
                Vector3 v = mUnitComponent.Velocity - neighbor.Velocity;
                float a = Vector3.Dot(v, v);
                float b = Vector3.Dot(w, v);
                float c = Vector3.Dot(w, w) - radiusSq;
                float discr = b * b - a * c;
                if (discr > .0f && (a < -kEpsilon || a > kEpsilon))
                {
                    discr = Mathf.Sqrt(discr);
                    float t = (b - discr) / a;
                    if (t > 0)
                    {
                        mUnitComponent.Acceleration += -kScaling * Mathf.Exp(-t / kExponentialCutoff) * (v - (b * v - a * w) / discr) / (a * Mathf.Pow(t, kPowerLawExponent)) * (kPowerLawExponent / t + 1 / kExponentialCutoff);
                    }
                }
            }
        }
    }

}
