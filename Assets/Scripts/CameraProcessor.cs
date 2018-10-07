/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class CameraProcessor : MonoBehaviour
{
    public Transform UnitToFollow;

	void Update ()
    {
        Vector3 newPosition = new Vector3(UnitToFollow.position.x, transform.position.y, UnitToFollow.position.z);
        transform.position = newPosition;
	}
}
