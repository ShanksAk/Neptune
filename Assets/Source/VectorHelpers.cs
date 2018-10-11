/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

class VectorHelpers
{
    public static Vector3 Vector2ToVector3(Vector2 vector2, float y = 0f)
    {
        return new Vector3(vector2.x, y, vector2.y);
    }

    public static Vector2 Vector3ToVector2(Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.z);
    }
}