using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class FieldingPositionManager : MonoBehaviour
{
    public Transform player; // Drag your character here
    public TextMeshProUGUI positionText; // Drag your TMP text here

    void Update()
    {
        Vector3 pos = player.position;
        string fieldPosition = GetFieldingZone(pos.x, pos.z);
        positionText.text = "Standing at: " + fieldPosition;
    }

    string GetFieldingZone(float x, float z)
    {
        // SHORT/MID RANGE (15m–30m radius)
        if (IsInRect(x, z, -10, 10, -40, -28)) return "Mid-On";
        if (IsInRect(x, z, -10, 10, 28, 40)) return "Mid-Off";
        if (IsInRect(x, z, 25, 50, 30, 60)) return "Cover";
        if (IsInRect(x, z, -50, -25, 30, 60)) return "Square Leg";
        if (IsInRect(x, z, -60, -35, -15, 15)) return "Slip";
        if (IsInRect(x, z, 35, 60, -15, 15)) return "Point";

        // DEEP RANGE (Beyond 30m to boundary)
        if (IsInRect(x, z, -20, 20, -75, -40)) return "Long-On";
        if (IsInRect(x, z, -20, 20, 40, 75)) return "Long-Off";
        if (IsInRect(x, z, 50, 75, 30, 70)) return "Deep Cover";
        if (IsInRect(x, z, -75, -50, 30, 70)) return "Deep Square Leg";
        if (IsInRect(x, z, 60, 75, -70, -40)) return "Third Man";
        if (IsInRect(x, z, -75, -60, -70, -40)) return "Fine Leg";

        // KEEPING/GULLY/SLIP ZONES (very close)
        if (IsInRect(x, z, -8, 8, -15, -8)) return "Keeper";
        if (IsInRect(x, z, -15, -8, -20, -8)) return "Leg Slip";
        if (IsInRect(x, z, 8, 15, -20, -8)) return "First Slip";

        return "Unknown Position";
    }

    // Helper function to define rectangular zones
    bool IsInRect(float x, float z, float minX, float maxX, float minZ, float maxZ)
    {
        return x >= minX && x <= maxX && z >= minZ && z <= maxZ;
    }
}

