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
            CalculateAvoidanceAcceleration(mUnitComponent, neighbor.Position, neighbor.Radius, neighbor.Velocity);
        }

        foreach (ObstacleComponent obstacle in mUnitComponent.Obstacles)
        {
            CalculateAvoidanceAcceleration(mUnitComponent, obstacle.Position, obstacle.Radius, Vector2.zero);
        }
    }

    private void CalculateAvoidanceAcceleration(UnitComponent mUnitComponent, Vector2 obstaclePosition, float obstacleRadius, Vector2 obstacleVelocity)
    {
        float distanceSq = (obstaclePosition - mUnitComponent.Position).sqrMagnitude;
        float radiusSq = Mathf.Pow((obstacleRadius + mUnitComponent.Radius), 2);
        if (distanceSq != radiusSq)
        {
            if (distanceSq < radiusSq)
            {
                radiusSq = Mathf.Pow((obstacleRadius + mUnitComponent.Radius - Mathf.Sqrt(distanceSq)), 2);
            }

            Vector2 w = obstaclePosition - mUnitComponent.Position;
            Vector2 v = mUnitComponent.Velocity - obstacleVelocity;
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
