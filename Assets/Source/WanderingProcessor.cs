/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class WonderingProcessor : MonoBehaviour
{
    private UnitComponent mUnitComponent;

    internal void Initialize()
    {
        mUnitComponent = GetComponent<UnitComponent>();
    }

    internal void Tick()
    {
    }
}
