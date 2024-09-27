using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> wallsToLock;
    [SerializeField] private GameObject enemySpawnManager;
    [SerializeField] private BoxCollider2D objectCollider;

    private void Start()
    {
        objectCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject wall in wallsToLock)
                wall.SetActive(true);
            enemySpawnManager.SetActive(true);
            objectCollider.enabled = false;
            enemySpawnManager.GetComponent<EnemySpawnManager>().trigger = this;
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject wall in wallsToLock)
            wall.SetActive(false);
    }
}
