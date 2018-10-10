/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class MoverProcessor : MonoBehaviour
{
    private UnitComponent mUnitComponent;

    internal void Initialize()
    {
        mUnitComponent = GetComponent<UnitComponent>();
    }

    internal void Tick()
    {
        mUnitComponent.Velocity += (mUnitComponent.Acceleration * Time.deltaTime);
        mUnitComponent.Velocity = Vector3.ClampMagnitude(mUnitComponent.Velocity, mUnitComponent.MaxVelocity);

        transform.position += mUnitComponent.Velocity * Time.deltaTime;
	}
}
