using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;

    void Start()
    {
        Cursor.visible = false; // Make cursor invisible
        Cursor.lockState = CursorLockMode.Locked; // Lock so that the cursor is in the middle of the screen
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0); // parameters are in order x, y, z

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { transform.Translate(0, 0, -speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { transform.Translate(speed * Time.deltaTime, 0, 0);  }
    }
}
