using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{

    public float amount;
    public UnityEvent onDeath;

    void Update()
    {
        if (amount <= 0)
        {
            Debug.Log($"Life <= 0 detected! Amount: {amount}"); // Add this
            Debug.Log("Invoking onDeath event..."); // Add this
            onDeath.Invoke();
            Debug.Log("Destroying gameObject..."); // Add this
            Destroy(gameObject);
        }
    }
}
