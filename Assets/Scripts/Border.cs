using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Border 
{
    public static Camera gameCamera = Camera.main;
    public static float minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
    public static float minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    public static float maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    public static float maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    
}
