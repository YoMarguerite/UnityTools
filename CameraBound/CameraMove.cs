using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class CameraMove : MonoBehaviour
{
    #region Variables

    private Vector3 Origin;
    private Vector3 Difference;

    private Camera MainCamera;

    private bool IsDragging;

    private Bounds CameraBounds;

    #endregion

    private Vector3 GetMousePosition => MainCamera.ScreenToWorldPoint(new Vector3(-Input.mousePosition.x, -Input.mousePosition.y, -10f));

    private void Awake() => MainCamera = Camera.main;

    private void LateUpdate()
    {
        if (!UITest.IsPointerOverUIElement())
        {
            Setup();

            if (Input.GetMouseButton(0))
            {
                if (Input.GetMouseButtonDown(0) && IsDragging == false)
                {
                    IsDragging = true;
                    Origin = GetMousePosition;
                }

                Difference = GetMousePosition - Origin;
            }
            else
            {
                IsDragging = false;
            }

            if (IsDragging)
            {
                Camera.main.transform.position = GetCameraBounds(
                    new Vector3(
                        Camera.main.transform.position.x - Difference.x,
                        Camera.main.transform.position.y - Difference.y,
                        -10f
                    )
                );
            }
        }        
    }

    public void Setup()
    {
        var height = 2.0f * Math.Abs(MainCamera.transform.position.z) * Mathf.Tan(MainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        var width = height * MainCamera.aspect;

        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.extents.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.extents.y - height;

        CameraBounds = new Bounds();
        CameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
            );
    }

    public void RePositionCamera()
    {
        Camera.main.transform.position = GetCameraBounds(Camera.main.transform.position);
    }

    public Vector3 GetCameraBounds(Vector3 target)
    {
        return new Vector3(
            Mathf.Clamp(target.x, CameraBounds.min.x, CameraBounds.max.x),
            Mathf.Clamp(target.y, CameraBounds.min.y, CameraBounds.max.y),
            target.z
        );
    }
}
