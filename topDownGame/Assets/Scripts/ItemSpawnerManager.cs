using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnerManager : MonoBehaviour
{
    [SerializeField] private List<Transform> spawners;
    [SerializeField] private GameObject lifePowerUp;
    private float coolDown = 45f;
    private float waitTime = 0;
    [SerializeField] private int percentageProbability;

    private void Start()
    {
        spawners = new List<Transform>(GetComponentsInChildren<Transform>());
        spawners = spawners.Where(c => c.gameObject != this.gameObject).ToList(); // Filtro para ignorar al padre de la jerarquia
        waitTime = coolDown + Time.time;
        percentageProbability = 75;
    }

    private void Update()
    {
        if(Time.time > waitTime)
        {
            TryGeneratePowerUp();
        }
    }

    void TryGeneratePowerUp()
    {
        int probability = Random.Range(1, 101);
        if(probability >= percentageProbability)
        {
            int index = Random.Range(0, spawners.Count);
            Instantiate(lifePowerUp, spawners[index].position, Quaternion.identity);
        }
        waitTime = coolDown + Time.time;
    }
}
