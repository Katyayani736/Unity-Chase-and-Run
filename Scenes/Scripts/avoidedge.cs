using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class avoiedge : MonoBehaviour
{
    public Transform plane; // Reference to the plane object
    private float bufferDistance = 1f; // Minimum distance from edge considered safe
    private float forceStrength = 10f; // Strength of the force pushing back from edges

    void Update()
    {
        if (plane == null)
        {
            Debug.LogError("StayOnPlane script: 'plane' variable not set!");
            return;
        }

        // Calculate plane boundaries
        float planeXMin = plane.position.x - plane.localScale.x / 2f + bufferDistance;
        float planeXMax = plane.position.x + plane.localScale.x / 2f - bufferDistance;
        float planeZMin = plane.position.z - plane.localScale.z / 2f + bufferDistance;
        float planeZMax = plane.position.z + plane.localScale.z / 2f - bufferDistance;

        // Get current position
        Vector3 currentPos = transform.position;

        // Distance from each edge (consider buffer zone)
        float distanceFromXMin = Mathf.Clamp(currentPos.x - planeXMin, 0f, Mathf.Infinity);
        float distanceFromXMax = Mathf.Clamp(planeXMax - currentPos.x, 0f, Mathf.Infinity);
        float distanceFromZMin = Mathf.Clamp(currentPos.z - planeZMin, 0f, Mathf.Infinity);
        float distanceFromZMax = Mathf.Clamp(planeZMax - currentPos.z, 0f, Mathf.Infinity);

        // Force calculation based on proximity to edges
        Vector3 force = Vector3.zero;
        if (distanceFromXMin < bufferDistance)
        {
            force.x = -forceStrength * (distanceFromXMin / bufferDistance); // Push away from X edge
        }
        if (distanceFromXMax < bufferDistance)
        {
            force.x = forceStrength * (distanceFromXMax / bufferDistance); // Push away from opposite X edge
        }
        if (distanceFromZMin < bufferDistance)
        {
            force.z = -forceStrength * (distanceFromZMin / bufferDistance); // Push away from Z edge
        }
        if (distanceFromZMax < bufferDistance)
        {
            force.z = forceStrength * (distanceFromZMax / bufferDistance); // Push away from opposite Z edge
        }

        // Apply force using Rigidbody (if applicable)
        if (GetComponent<Rigidbody>() != null)
        {
            GetComponent<Rigidbody>().AddForce(force);
        }
        else
        {
            // Handle movement without Rigidbody (alternative approach needed)
            Debug.LogWarning("StayOnPlane script: No Rigidbody found. Movement might be affected!");

            // Alternative approach (transform position adjustment):
            // currentPos.x = Mathf.Clamp(currentPos.x, planeXMin, planeXMax);
            // currentPos.z = Mathf.Clamp(currentPos.z, planeZMin, planeZMax);
            // transform.position = currentPos;
        }
    }
}
