/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class UnitProcessor : MonoBehaviour
{
    private UnitComponent mUnitComponent;
    private MoverProcessor mMoverProcessor;
    private AvoidanceProcessor mAvoidanceProcessor;

    private void Start()
    {
        mUnitComponent = GetComponent<UnitComponent>();
        mUnitComponent.Initialize();

        mMoverProcessor = GetComponent<MoverProcessor>();
        mMoverProcessor.Initialize();

        mAvoidanceProcessor = GetComponent<AvoidanceProcessor>();
        mAvoidanceProcessor.Initialize();
    }

    private void Update ()
    {
        mMoverProcessor.Calculate();
        mAvoidanceProcessor.Tick();
        mMoverProcessor.Tick();
    }
}
