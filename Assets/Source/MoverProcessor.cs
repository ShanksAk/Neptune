﻿/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class MoverProcessor : MonoBehaviour
{
    private const float kEpsilon = 0.00001f;
    private const float kGoalRadiusSq = 1f;
    private const float kRelaxationTime = 0.54f;

    private UnitComponent mUnitComponent;
    private Vector2 mPreferredVelocity;

    internal void Initialize()
    {
        mUnitComponent = GetComponent<UnitComponent>();
    }

    internal void Calculate()
    {
        if (mUnitComponent.UseDestination)
        {
            mPreferredVelocity = mUnitComponent.Destination - mUnitComponent.Position;
            if (mPreferredVelocity.sqrMagnitude < kGoalRadiusSq)
            {
                mUnitComponent.Acceleration = Vector2.zero;
                mUnitComponent.Velocity = Vector2.zero;
                return;
            }

            mPreferredVelocity *= (mUnitComponent.Speed / mPreferredVelocity.magnitude);
            mUnitComponent.Acceleration = ((mPreferredVelocity - mUnitComponent.Velocity) / kRelaxationTime);
        }
        else
        {
            mUnitComponent.Acceleration = (mUnitComponent.Direction * mUnitComponent.Speed);
        }
    }

    internal void Tick()
    {
        mUnitComponent.Acceleration = Vector2.ClampMagnitude(mUnitComponent.Acceleration, mUnitComponent.MaxAcceleration);

        mUnitComponent.Velocity += (mUnitComponent.Acceleration * Time.deltaTime);
        mUnitComponent.Velocity = Vector2.ClampMagnitude(mUnitComponent.Velocity, mUnitComponent.MaxVelocity);

        if (mUnitComponent.Velocity.sqrMagnitude > kEpsilon)
        {
            mUnitComponent.Position += mUnitComponent.Velocity * Time.deltaTime;
            transform.position = VectorHelpers.Vector2ToVector3(mUnitComponent.Position, transform.position.y);
        }
	}
}
