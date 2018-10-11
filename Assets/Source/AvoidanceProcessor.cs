/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
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
        foreach (UnitComponent neighbor in mUnitComponent.Neighbors)
        {
            float distanceSq = (neighbor.Position - mUnitComponent.Position).sqrMagnitude;
            float radiusSq = Mathf.Pow((neighbor.Radius + mUnitComponent.Radius), 2);
            if (distanceSq != radiusSq)
            {
                if (distanceSq < radiusSq)
                {
                    radiusSq = Mathf.Pow((neighbor.Radius + mUnitComponent.Radius - Mathf.Sqrt(distanceSq)), 2);
                }

                Vector2 w = neighbor.Position - mUnitComponent.Position;
                Vector2 v = mUnitComponent.Velocity - neighbor.Velocity;
                float a = Vector2.Dot(v, v);
                float b = Vector2.Dot(w, v);
                float c = Vector2.Dot(w, w) - radiusSq;
                float discr = ((b * b) - (a * c));
                if (discr > .0f && (a < -kEpsilon || a > kEpsilon))
                {
                    discr = Mathf.Sqrt(discr);
                    float t = ((b - discr) / a);
                    if (t > 0)
                    {
                        mUnitComponent.Acceleration += -kScaling * Mathf.Exp(-t / kExponentialCutoff) * (v - (b * v - a * w) / discr) / (a * Mathf.Pow(t, kPowerLawExponent)) * (kPowerLawExponent / t + 1 / kExponentialCutoff);
                    }
                }
            }
        }

        foreach (ObstacleComponent obstacle in mUnitComponent.Obstacles)
        {
            float distanceSq = (obstacle.Position - mUnitComponent.Position).sqrMagnitude;
            float radiusSq = Mathf.Pow((obstacle.Radius + mUnitComponent.Radius), 2);
            if (distanceSq != radiusSq)
            {
                if (distanceSq < radiusSq)
                {
                    radiusSq = Mathf.Pow((obstacle.Radius + mUnitComponent.Radius - Mathf.Sqrt(distanceSq)), 2);
                }

                Vector2 w = obstacle.Position - mUnitComponent.Position;
                Vector2 v = mUnitComponent.Velocity;
                float a = Vector2.Dot(v, v);
                float b = Vector2.Dot(w, v);
                float c = Vector2.Dot(w, w) - radiusSq;
                float discr = ((b * b) - (a * c));
                if (discr > .0f && (a < -kEpsilon || a > kEpsilon))
                {
                    discr = Mathf.Sqrt(discr);
                    float t = ((b - discr) / a);
                    if (t > 0)
                    {
                        mUnitComponent.Acceleration += -kScaling * Mathf.Exp(-t / kExponentialCutoff) * (v - (b * v - a * w) / discr) / (a * Mathf.Pow(t, kPowerLawExponent)) * (kPowerLawExponent / t + 1 / kExponentialCutoff);
                    }
                }
            }
        }
    }

}
