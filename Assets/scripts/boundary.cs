#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class BoundaryRopeGenerator : MonoBehaviour
{
    public int segments = 100;
    public float xRadius = 75f;
    public float zRadius = 65f;
    public float yHeight = 0.1f;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.loop = true;
        line.useWorldSpace = false;
        DrawRope();
    }

    void OnValidate()
    {
        if (!Application.isPlaying)
        {
            line = GetComponent<LineRenderer>();
            line.positionCount = segments + 1;
            line.loop = true;
            line.useWorldSpace = false;
            DrawRope();
        }
    }

    void DrawRope()
    {
        float angle = 0f;
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * zRadius;
            line.SetPosition(i, new Vector3(x, yHeight, z));
            angle += 360f / segments;
        }
    }
}