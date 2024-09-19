using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<Transform> spawnPositions;
    private float coolDown = 5f;
    private float waitTime = 0;
    private int enemiesAlive;
    [SerializeField] private int amountOfEnemiesOnScreen;

    void Start()
    {
        enemiesAlive = 0;
        spawnPositions =  new List<Transform>(GetComponentsInChildren<Transform>());
        spawnPositions = spawnPositions.Where(c => c.gameObject != this.gameObject).ToList();
        waitTime = Time.time + coolDown;
    }


    void Update()
    {
        if(Time.time > waitTime && enemiesAlive < amountOfEnemiesOnScreen)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Count);
        int spawnIndex = Random.Range(0, spawnPositions.Count);
        IEnemy enemy = Instantiate(enemies[enemyIndex], spawnPositions[spawnIndex].position, Quaternion.identity).GetComponent<IEnemy>();
        enemy.spawn = this;
        AddEnemy();
        waitTime = Time.time + coolDown;
    }

    void AddEnemy()
    {
        enemiesAlive++;
    }

    public void SubstractEnemy()
    {
        enemiesAlive--;
    }
}
