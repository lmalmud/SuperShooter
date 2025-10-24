using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    private Vector2 movementValue;
    private float lookValue;

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * speed;
    }

    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }


    public void Awake()
    {
        Cursor.visible = false; // Make cursor invisible
        Cursor.lockState = CursorLockMode.Locked; // Lock so that the cursor is in the middle of the screen

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddRelativeForce(
            movementValue.x * Time.deltaTime,
            0,
            movementValue.y * Time.deltaTime
        );

        transform.Rotate(0, lookValue * Time.deltaTime, 0);
    }
}
