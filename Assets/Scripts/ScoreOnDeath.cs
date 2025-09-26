using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount; // how much killing this enemy is worth

    void OnDestroy()
    {
        ScoreManager.instance.amount += amount;
    }
}
