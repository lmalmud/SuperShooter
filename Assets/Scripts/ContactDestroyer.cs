using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{

    void OnTriggerEnter()
    {
        // autodestroies on contact with something
        Destroy(gameObject);
    }

}
