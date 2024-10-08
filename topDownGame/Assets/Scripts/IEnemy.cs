using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    int Health { get; set; }
    EnemySpawnManager spawn { get; set; }

    void Movement();
    void Attack();
    void TakeDamage(int damage);
}
