/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class NeighborsProcessor : MonoBehaviour
{
    private UnitComponent mUnitComponent;

    private void Start()
    {
        mUnitComponent = GetComponent<UnitComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        UnitComponent awarenessUnit = other.gameObject.GetComponent<UnitComponent>();
        if (awarenessUnit != null && !mUnitComponent.Neighbors.Contains(awarenessUnit))
        {
            mUnitComponent.Neighbors.Add(awarenessUnit);
        }

        ObstacleComponent obstacle = other.gameObject.GetComponent<ObstacleComponent>();
        if (obstacle != null && !mUnitComponent.Obstacles.Contains(obstacle))
        {
            mUnitComponent.Obstacles.Add(obstacle);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UnitComponent awarenessUnit = other.gameObject.GetComponent<UnitComponent>();
        if (awarenessUnit != null && mUnitComponent.Neighbors.Contains(awarenessUnit))
        {
            mUnitComponent.Neighbors.Remove(awarenessUnit);
        }

        ObstacleComponent obstacle = other.gameObject.GetComponent<ObstacleComponent>();
        if (obstacle != null && mUnitComponent.Obstacles.Contains(obstacle))
        {
            mUnitComponent.Obstacles.Remove(obstacle);
        }
    }

}
