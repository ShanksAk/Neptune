/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    public const string kUnitTag = "Unit";

    public SphereCollider AwarenessSphere;

    public float MaxVelocity = 2f;
    public float MaxAcceleration = 20f;
    public float Speed = 1f;

    internal bool UseDestination = false;
    internal Vector3 Destination = Vector3.zero;
    internal Vector3 Direction = Vector3.zero;

    internal Vector3 Acceleration = Vector3.zero;
    internal Vector3 Velocity = Vector3.zero;

    internal HashSet<UnitComponent> Neighbors = new HashSet<UnitComponent>();

    public void Initialize()
    {
        GroupComponent groupComponent = transform.parent.GetComponent<GroupComponent>();
        UseDestination = groupComponent.UseDestination;
        if (UseDestination)
        {
            Destination = groupComponent.DestinationWaypoint.position;
        }
        else
        {
            Direction = groupComponent.Direction;
        }
    }
}
