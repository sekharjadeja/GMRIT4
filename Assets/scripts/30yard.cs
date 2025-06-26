using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InnerCircleDrawer : MonoBehaviour
{
    public int segments = 100;
    public float radius = 27.43f;  // 30 yards in meters
    public float yHeight = 0.01f;

    private LineRenderer line;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    void OnValidate()
    {
        DrawCircle();  // Force redraw in editor
    }

    void Update()
    {
        DrawCircle();
    }

    void DrawCircle()
    {
        if (line == null) line = GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        float angle = 0f;

        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            line.SetPosition(i, new Vector3(x, yHeight, z));
            angle += 360f / segments;
        }
    }
}
