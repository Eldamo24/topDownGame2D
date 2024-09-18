using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPowerUp : MonoBehaviour
{
    private int life = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().AddLife(life);
            Destroy(gameObject);
        }
    }
}
