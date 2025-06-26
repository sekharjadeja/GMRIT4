using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;

    // Optional: limit ground boundary (adjust as per your ground scale)
    public float xLimit = 70f;
    public float zLimit = 65f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0, v) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Clamp position to stay within ground
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        pos.z = Mathf.Clamp(pos.z, -zLimit, zLimit);
        transform.position = pos;

        // Optional: face movement direction
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }
}

