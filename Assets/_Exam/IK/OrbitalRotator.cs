using System;
using UnityEngine;

public class OrbitalRotator : MonoBehaviour
{
    [SerializeField] private float radius = 2f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 axis = Vector3.up;

    private float angle;
    private Vector3 centerPos;

    private void Start()
    {
        centerPos = transform.position;
    }

    private void Update()
    {
        angle += speed * Time.deltaTime;

        // Calculate position on the unit circle with the specified radius
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Rotate based on the specified axis
        Vector3 offset = new Vector3(
            axis.x == 0 ? x : 0,   // Rotate along X if axis.x is 0
            axis.y == 0 ? x : 0,   // Rotate along Y if axis.y is 0
            axis.z == 0 ? z : 0    // Rotate along Z if axis.z is 0
        );

        // Set the object's position relative to its origin
        transform.localPosition = centerPos + offset;
    }
}
