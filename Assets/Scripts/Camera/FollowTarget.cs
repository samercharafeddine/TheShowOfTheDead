using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 offset;
    private Vector3 currentVelocity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate target position
        Vector3 targetPosition = target.position + offset;

        // Calculate interpolation factor
        float interpolationFactor = Time.deltaTime / (Time.deltaTime + smoothTime);

        // Interpolate between current position and target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, interpolationFactor);
    }
}
