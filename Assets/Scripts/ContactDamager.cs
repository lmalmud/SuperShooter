using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter(Collider other)
    {
        /*
        Destroy(gameObject);

        Life life = other.GetComponent<Life>();

        if (life != null)
        {
            life.amount -= damage;
            print("you hit one of the ohters");
        }
        */

        // Debug: What did we hit?
        Debug.Log($"ContactDamager hit: {other.gameObject.name} (Tag: {other.tag})");
        
        // Debug: List all components on the hit object
        Component[] components = other.GetComponents<Component>();
        Debug.Log($"Components on {other.name}: {string.Join(", ", System.Array.ConvertAll(components, c => c.GetType().Name))}");
        
        // MOVED DESTROY TO END - Important fix!
        
        Life life = other.GetComponent<Life>();

        if (life != null)
        {
            Debug.Log($"Life component found! Current health: {life.amount}, Damage dealt: {damage}");
            life.amount -= damage;
            Debug.Log($"New health after damage: {life.amount}");
            print("you hit one of the others");
        }
        else
        {
            Debug.Log($"No Life component found on {other.name}");
        }

        // Destroy bullet AFTER damage is dealt
        Destroy(gameObject);

    }
}
