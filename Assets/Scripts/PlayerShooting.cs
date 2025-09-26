using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{

    public GameObject prefab;

    public GameObject shootPoint;

    // Update was replaced by OnFire
    void OnFire(InputValue value)
    {
        if (value.isPressed) // only runs when the key is released
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            print("click!!!");
        }
        /*
            // GetKeyDown will only execute once they key has been pressed and released,
            // where GetKey just activated when it was pressed
            // Mouse0 = left click, Mouse1 = right click, Mouse2 = middle click
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Need to pass the position and angle as parameters so that the 
                // bullet spawns in the desired position
                Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);

                Alternate method of instantiation:
                GameObject clone = Instantiate(prefab);
                clone.transform.position = transform.position;
                clone.transform.rotation = transform.rotation;
            }
            */
        }
}
