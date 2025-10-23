using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{

    public GameObject particlePrefab;

    void Awake()
    {
        var life = GetComponent<life>();
        life.onDeath.AddListener(ExplosionOnDeath);
    }

    void OnDeath()
    {
        Instantiate(particlePrefab,
        transform.position,
        transform.rotation);
    }

}
