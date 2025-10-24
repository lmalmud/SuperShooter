using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target; // Assign your character's transform here

    // FPS-ish offsets so the camera sits slightly behind and to the side of the head
    public float distance = 0.6f;        // how far behind the player's head
    public float height = 1.7f;          // vertical offset (eye height)
    public float horizontalOffset = 0.25f; // offset to the right (hand/weapon visibility)

    // Where the camera should aim relative to the player
    public float lookAhead = 20f; // how far forward the camera looks (helps with aiming)
    public float lookUp = 0.1f;   // small upward bias so camera isn't pointed straight at feet

    // Smoothing (interpreted as a speed)
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position: at the player's eye, slightly behind and to the side
        Vector3 desiredPosition = target.position
                                  + target.up * height
                                  - target.forward * distance
                                  + target.right * horizontalOffset;

        // Smooth position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Look point ahead of the player so camera looks forward where the player aims
        Vector3 lookPoint = target.position + target.forward * lookAhead + Vector3.up * lookUp;

        // Smooth rotation towards that look point
        Quaternion desiredRotation = Quaternion.LookRotation(lookPoint - transform.position, Vector3.up);        
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
        
    }
}
