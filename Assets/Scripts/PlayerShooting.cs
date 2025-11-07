using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{

    public GameObject prefab;

    public int bulletsAmount=100;

    public GameObject shootPoint;
    public float fireRate;

    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update was replaced by OnFire
    void OnFire(InputValue value)
    {
        animator.SetBool("Shooting", value.isPressed);
        if (value.isPressed)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        else
        {
            CancelInvoke();
        }

    }

    private void Shoot()
    {
        if (bulletsAmount > 0 && Time.timeScale > 0) // only runs when the key is released
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
