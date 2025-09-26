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


        }

    }
}
