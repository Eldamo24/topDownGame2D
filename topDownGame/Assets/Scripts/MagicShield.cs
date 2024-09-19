using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MonoBehaviour
{
    [SerializeField] private int hits;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    public void ResetHits()
    {
        hits = 3;
    }

    public void Hit()
    {
        hits--;
        CheckDestroy();
    }

    void CheckDestroy()
    {
        if (hits <= 0)
        {
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            this.enabled = false;
        }
    }

    public void EnableShield()
    {
        spriteRenderer.enabled = true;
        circleCollider.enabled = true;
    }

   
}
