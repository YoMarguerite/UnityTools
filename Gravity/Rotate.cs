using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    Gravity gravity;

    void Update()
    {
        Vector3 direction = gravity.actualGravity.Perpendicular2();

        float rad = Mathf.Atan2(direction.y, direction.x);
        float angle = rad * (180 / Mathf.PI);

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.rotation = rotation;
    }
}
