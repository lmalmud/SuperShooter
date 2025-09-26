using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesManager : MonoBehaviour
{

    public List<Enemy> enemies;
    public UnityEvent onChanged; // list of existing enemies is different
    public static EnemiesManager instance;

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onChanged.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        onChanged.Invoke();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Duplicated EnemiesManager", gameObject);
        }
    }

}   
