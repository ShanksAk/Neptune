/// Copyright (c) 2018 All Rights Reserved. Maher Manoubi.
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    public int Speed = 1;
    public Vector3 Direction = Vector3.zero;
    public Vector3 MovementDelta = Vector3.zero;
    public List<UnitComponent> Neighbors = new List<UnitComponent>(20);
}
