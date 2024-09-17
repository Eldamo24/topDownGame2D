using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    private GameObject shield;

    private void Start()
    {
        shield = GameObject.Find("MagicShield");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shield.GetComponent<SpriteRenderer>().enabled = true;
            shield.GetComponent<CircleCollider2D>().enabled = true;
            Destroy(gameObject);
        }
    }
}
