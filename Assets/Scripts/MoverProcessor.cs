/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class MoverProcessor : MonoBehaviour
{
    public int Speed = 1;
    public Vector3 Direction;

	void Update ()
    {
        transform.position += ((Direction * Speed) * Time.deltaTime);
	}
}
