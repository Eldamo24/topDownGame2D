using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHit : MonoBehaviour
{
    private int damage = 30;
    private float duration = 1f;
    private Vector3 actualScale;
    private Vector3 targetScale = new Vector3(2f,2f,2f);
    public Exploder exploder;

    private void OnEnable()
    {
        actualScale = transform.localScale;
        StartCoroutine("ScaleObject");
    }

    IEnumerator ScaleObject()
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            transform.localScale = Vector2.Lerp(actualScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("ScaleObject");
        if(exploder != null)
            exploder.canAttack = false;
    }


}
