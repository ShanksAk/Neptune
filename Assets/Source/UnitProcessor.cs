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

        mMoverProcessor = GetComponent<MoverProcessor>();
        mMoverProcessor.Initialize();

        mAvoidanceProcessor = GetComponent<AvoidanceProcessor>();
        mAvoidanceProcessor.Initialize();
    }

    private void Update ()
    {
        mAvoidanceProcessor.Tick();
        mMoverProcessor.Tick();
    }
}
