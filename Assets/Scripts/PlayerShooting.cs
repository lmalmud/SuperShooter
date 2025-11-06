using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{

    public GameObject prefab;

    public int bulletsAmount=100;

    public GameObject shootPoint;

    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;

    // Update was replaced by OnFire
    void OnFire(InputValue value)
    {
        if (value.isPressed && bulletsAmount > 0) // only runs when the key is released
        {

            bulletsAmount--;

            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

            muzzleEffect.Play();
            shootSound.Play();
        }

    }
}
