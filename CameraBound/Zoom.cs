using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    public Camera cam;
    public CameraMove move;
    public float zoomMultiplier = 2;
    public float zoomMax = 50;
    public float zoomMin = 10;

    private void Start()
    {
        var resolutionCam = cam.aspect;
        var resolutionImage = (Math.Abs(Globals.WorldBounds.min.x) + Math.Abs(Globals.WorldBounds.extents.x)) /
            (Math.Abs(Globals.WorldBounds.min.y) + Math.Abs(Globals.WorldBounds.extents.y));

        float height = Globals.WorldBounds.extents.y;
        if (resolutionCam > resolutionImage)
        {
            float largeur = Globals.WorldBounds.extents.x;
            height = largeur / resolutionCam;
        }
        float oppose = height / 2;
        float tan = oppose / 10;
        float rad = Mathf.Atan(tan);
        zoomMax = (float)Math.Floor(rad / Mathf.Deg2Rad * 2);
    }

    void Update()
    {
        if (!UITest.IsPointerOverUIElement())
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                cam.fieldOfView -= cam.fieldOfView > zoomMin ? zoomMultiplier : 0;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                cam.fieldOfView += cam.fieldOfView < zoomMax ? zoomMultiplier : 0;
            }
            move.RePositionCamera();
        }
    }
}
