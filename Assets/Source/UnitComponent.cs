/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    public float MaxVelocity = 2f;
    public float MaxAcceleration = 100f;
    public float Speed = 1f;

    internal bool UseDestination = false;
    internal Vector2 Destination = Vector2.zero;
    internal Vector2 Direction = Vector2.zero;

    internal Vector2 Acceleration = Vector2.zero;
    internal Vector2 Velocity = Vector2.zero;
    internal Vector2 Position = Vector2.zero;
    internal float Radius = 0f;

    internal HashSet<UnitComponent> Neighbors = new HashSet<UnitComponent>();
    internal HashSet<ObstacleComponent> Obstacles = new HashSet<ObstacleComponent>();

    public void Initialize()
    {
        GroupComponent groupComponent = transform.parent.GetComponent<GroupComponent>();
        UseDestination = groupComponent.UseDestination;
        if (UseDestination)
        {
            Destination = VectorHelpers.Vector3ToVector2(groupComponent.DestinationWaypoint.position);
        }
        else
        {
            Direction = groupComponent.Direction;
        }
        Position = VectorHelpers.Vector3ToVector2(transform.position);
        Vector3 localScale = transform.localScale;
        float scale = ((localScale.x + localScale.y + localScale.z) / 3);
        Radius = (scale / 2);
    }
}
