/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    public const string kUnitTag = "Unit";

    public SphereCollider AwarenessSphere;

    internal float MaxVelocity = 2f;
    public float Speed = 1f;
    public Vector3 Direction = Vector3.zero;

    internal Vector3 Acceleration = Vector3.zero;
    internal Vector3 Velocity = Vector3.zero;

    internal HashSet<UnitComponent> Neighbors = new HashSet<UnitComponent>();
}
