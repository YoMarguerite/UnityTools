using System;
using UnityEngine;

public class SetWorldBounds : MonoBehaviour
{
    private void Awake()
    {
        var bounds = GetComponent<SpriteRenderer>().bounds;

        //bounds.min = new Vector3(bounds.min.x - (bounds.min.x * 5 / 100), bounds.min.y, bounds.min.z);
        //bounds.extents = new Vector3(bounds.extents.x - (bounds.extents.x * 5 / 100), bounds.extents.y, bounds.extents.z);

        Globals.WorldBounds = bounds;
    }
}