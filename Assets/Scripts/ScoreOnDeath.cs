using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount; // how much killing this enemy is worth
    private Life life; // store reference to the Life component for OnDestroy

    private void Awake()
    {

        life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);

    }

    void GivePoints()
    {
        ScoreManager.instance.amount += amount;
    }

    void OnDestroy()
    {
        if (life != null)
        {
            life.onDeath.RemoveListener(GivePoints);
        }
        
    }
}
