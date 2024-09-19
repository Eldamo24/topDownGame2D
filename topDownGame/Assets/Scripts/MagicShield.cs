using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MonoBehaviour
{
    private int hits;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;

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
        if(hits <= 0)
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
