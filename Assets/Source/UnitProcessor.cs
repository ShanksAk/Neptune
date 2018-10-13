/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class UnitProcessor : MonoBehaviour
{
    private UnitComponent mUnitComponent;
    private MoverProcessor mMoverProcessor;
    private AvoidanceProcessor mAvoidanceProcessor;

    public void Initialize()
    {
        mUnitComponent = GetComponent<UnitComponent>();
        mUnitComponent.Initialize();

        mMoverProcessor = GetComponent<MoverProcessor>();
        mMoverProcessor.Initialize();

        mAvoidanceProcessor = GetComponent<AvoidanceProcessor>();
        mAvoidanceProcessor.Initialize();
    }

    public void Tick ()
    {
        mMoverProcessor.Calculate();
        mAvoidanceProcessor.Tick();
        mMoverProcessor.Tick();
    }
}
