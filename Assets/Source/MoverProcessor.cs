/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using UnityEngine;

public class MoverProcessor : MonoBehaviour
{
    private UnitComponent unitComponent;

    private void Start ()
    {
        unitComponent = GetComponent<UnitComponent>();
    }

    private void Update ()
    {
        unitComponent.MovementDelta = ((unitComponent.Direction * unitComponent.Speed) * Time.deltaTime);
        transform.position += unitComponent.MovementDelta;
	}
}
