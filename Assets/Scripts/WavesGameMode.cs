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

        Debug.Log($"Player Life object: {playerLife?.gameObject.name}"); // Add this
        Debug.Log($"Player Base Life object: {playerBaseLife?.gameObject.name}"); // Add this

        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);

        Debug.Log("All listeners added successfully!"); // Add this
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
        Debug.Log("OnPlayerOrBaseDied called! Loading LoseScreen..."); // Add this line
    SceneManager.LoadScene("LoseScreen");
        SceneManager.LoadScene("LoseScreen");
    }
}
