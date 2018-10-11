/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class ObstacleComponent : MonoBehaviour
{
    public float Radius = 0f;
    internal Vector2 Position;

    private void Start()
    {
        Position = VectorHelpers.Vector3ToVector2(transform.position);
    }
}
