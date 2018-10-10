/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class MoverProcessor : MonoBehaviour
{
    private const float kEpsilon = 0.00001f;
    private const float kGoalRadiusSq = 0.25f;
    private const float kRelaxationTime = 0.54f;

    private UnitComponent mUnitComponent;
    private Vector3 mPreferredVelocity;

    internal void Initialize()
    {
        mUnitComponent = GetComponent<UnitComponent>();
    }

    internal void Calculate()
    {
        if (mUnitComponent.UseDestination)
        {
            mPreferredVelocity = mUnitComponent.Destination - mUnitComponent.transform.position;
            if (mPreferredVelocity.sqrMagnitude < kGoalRadiusSq)
            {
                mPreferredVelocity = Vector3.zero; // Arrived!
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
        mUnitComponent.Acceleration = Vector3.ClampMagnitude(mUnitComponent.Acceleration, mUnitComponent.MaxAcceleration);

        mUnitComponent.Velocity += (mUnitComponent.Acceleration * Time.deltaTime);
        mUnitComponent.Velocity = Vector3.ClampMagnitude(mUnitComponent.Velocity, mUnitComponent.MaxVelocity);

        if (mUnitComponent.Velocity.sqrMagnitude > kEpsilon)
        {
            transform.position += mUnitComponent.Velocity * Time.deltaTime;
        }
	}
}
