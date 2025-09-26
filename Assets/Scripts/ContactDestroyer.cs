using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // autodestroies on contact with something
        Destroy(gameObject);
        print("i hit something");
        Destroy(other.gameObject);
    }

}
