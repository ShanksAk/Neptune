/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using System.Collections.Generic;
using UnityEngine;

public class GameProcessor : MonoBehaviour
{
    internal UnitProcessor[] Units;

    private void Start()
    {
        Units = FindObjectsOfType<UnitProcessor>();

        foreach (UnitProcessor unit in Units)
        {
            unit.Initialize();
        }

        Debug.Log(string.Format("Number of units: {0}", Units.Length));
    }

    private void Update()
    {
        float startTime = Time.realtimeSinceStartup;

        foreach (UnitProcessor unit in Units)
        {
            unit.Tick();
        }

        float endTime = Time.realtimeSinceStartup;
        float duration = endTime - startTime;
        if (duration > 0.01f)
        {
            Debug.Log(string.Format("Avoidance Calculation: {0}", duration));
        }
    }
}
