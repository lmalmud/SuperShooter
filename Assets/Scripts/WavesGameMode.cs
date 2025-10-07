using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WavesGameMode : MonoBehaviour
{

    [SerializeField] private Life playerLife;
    [SerializeField] private Life playerBaseLife;


    void Start()
    {

        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);

    }
    void CheckWinCondition()
    {
        if (EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }

    }

    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
