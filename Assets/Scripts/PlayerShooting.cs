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
            /*
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            */

         if (value.isPressed) // only runs when the key is pressed
        {
            Debug.Log("Fire button pressed!"); // Debug: Is the input working?
            
            if (prefab == null)
            {
                Debug.LogError("Prefab is not assigned in PlayerShooting!");
                return;
            }
            
            if (shootPoint == null)
            {
                Debug.LogError("ShootPoint is not assigned in PlayerShooting!");
                return;
            }
            
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            
            Debug.Log($"Bullet created: {clone.name} at position {clone.transform.position}");
            
            // Debug: Check if the bullet has the required components
            ContactDamager damager = clone.GetComponent<ContactDamager>();
            if (damager == null)
            {
                Debug.LogError("Bullet prefab is missing ContactDamager component!");
            }
            else
            {
                Debug.Log($"Bullet damage set to: {damager.damage}");
            }
        }

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
